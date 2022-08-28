using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerInput playerInput;
    private Rigidbody rBody;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        playerInput = GetComponent<PlayerInput>();
        rBody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        anim.SetFloat("Speed",Mathf.Abs(rBody.velocity.x));
        if (playerInput.jumpPressed)
        {
            anim.SetTrigger("Jump");
        }

        if(rBody.velocity.y < -1 || rBody.velocity.y > 1)
        {
            anim.SetBool("In-Air", true);
        }
        else
        {
            anim.SetBool("In-Air", false);
        }
    }
}