using UnityEngine;

public class Barrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bacteria")
        {
            Destroy(other.gameObject);
        }
    }
}