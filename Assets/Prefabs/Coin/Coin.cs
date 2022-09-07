using UnityEngine;

public class Coin : MonoBehaviour
{
    public int currencyValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Inventory>())
        {
            Inventory inventory = other.GetComponent<Inventory>();
            inventory.ChangeCurrency(currencyValue);
            Destroy(gameObject);
        }
    }
}