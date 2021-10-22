using UnityEngine;

public class CheckpointStart : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("OnEnterPlatform");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.SetTrigger("OnLeavePlatform");
        }
    }
}
