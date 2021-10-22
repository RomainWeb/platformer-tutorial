using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject objectToDestroy;
    public int healPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.instance.AddCherries(1);
            PlayerHealth.instance.Heal(healPoints);
            Destroy(objectToDestroy);
        }
    }
}
