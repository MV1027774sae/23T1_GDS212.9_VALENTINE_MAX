using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YBotPistolAnimScript : MonoBehaviour
{
    [SerializeField] private PlayerMovementTutorial playerMovement;
    private Animator anim;
    private bool isWalking;

    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(anim);
    }

    void Update()
    {
        if (Input.GetKey("w"))
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);

        if (Input.GetKey("w") && Input.GetKey("left shift"))
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
        if (Input.GetKey("mouse 0"))
            anim.SetTrigger("shoot");

    }
}
