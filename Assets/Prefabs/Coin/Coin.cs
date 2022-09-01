using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Inventory>())
        {
            Inventory inventory = other.GetComponent<Inventory>();
            inventory.ChangeCurrency(1);
            Destroy(gameObject);
        }
    }
}