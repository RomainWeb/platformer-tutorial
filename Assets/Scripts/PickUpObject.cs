using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventory.instance.AddCherries(1);
            Destroy(objectToDestroy);
        }
    }
}
