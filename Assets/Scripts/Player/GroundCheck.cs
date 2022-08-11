using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("Ground is Gorund");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}