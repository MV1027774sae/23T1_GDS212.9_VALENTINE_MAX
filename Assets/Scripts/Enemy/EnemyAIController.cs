using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 playerVector;
    [SerializeField] private LayerMask isGround, isPlayer;

    [SerializeField] private Vector3 walkPoint;
    private bool walkPointSet;
    [SerializeField] private float walkPointRange;

    [SerializeField] private float timeBetweenAttacks;
    private bool alreadyAttacked;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileForceForward;
    [SerializeField] private float projectileForceUp;

    [SerializeField] private float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange;

    [SerializeField] private ParticleSystem muzzleFlash;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gunshot;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        //agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerVector = new Vector3 (player.position.x, player.position.y, player.position.z);

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        //if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    //private void Patroling()
    //{
    //    if (!walkPointSet) SearchWalkPoint();

    //    if (walkPointSet)
    //        agent.SetDestination(walkPoint);

    //    Vector3 distanceToWalkPoint = transform.position - walkPoint;

    //    if (distanceToWalkPoint.magnitude < 1f)
    //    {
    //        walkPointSet = false;
    //        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    //    }
    //}

    //private void SearchWalkPoint()
    //{
    //    float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //    float randomX = Random.Range(-walkPointRange, walkPointRange);

    //    walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
    //        walkPointSet = true;
    //}

    //private void ChasePlayer()
    //{
    //    agent.SetDestination(player.position);
    //}

    private void AttackPlayer()
    {
        //agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Vector3 aimDir = (playerVector - shootPoint.position).normalized;
            Rigidbody rb = Instantiate(projectile, shootPoint.position, Quaternion.LookRotation(aimDir, Vector3.up)).GetComponent<Rigidbody>();
            muzzleFlash.Play();
            audioSource.PlayOneShot(gunshot);

            rb.AddForce(transform.forward * projectileForceForward, ForceMode.Impulse);
            rb.AddForce(transform.up * projectileForceUp, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks * Time.deltaTime * 60);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
