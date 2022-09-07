using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ground")
        {
            isGrounded = true;
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