using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform playerSpawn;
    public Animator animator;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSpawn.position = transform.position;
            animator.SetTrigger("OnEnter");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
