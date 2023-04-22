using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth = 50;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject end;

    private void Start()
    {
        player = GameObject.Find("Player");
        end = GameObject.Find("End");
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);

            player.GetComponent<ThirdPersonShooterController>().deadeyeResource += player.GetComponent<ThirdPersonShooterController>().deadeyeIncrease;
            end.GetComponent<EndGoal>().EnemyKilled();
        }
    }
}
