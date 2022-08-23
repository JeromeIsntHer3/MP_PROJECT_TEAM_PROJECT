using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnim;

    void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    public void SetSpeed(string animName, float speed)
    {
        playerAnim.SetFloat(animName, speed);
    }

    public void TriggerJump(string animName)
    {
        playerAnim.SetTrigger(animName);
    }

    public void SetBool(string animName, bool set)
    {
        playerAnim.SetBool(animName, set);
    }
}