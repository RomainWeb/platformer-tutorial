using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvicible = false;
    public float invicibilityFlashDelay = 0.2f;
    public float invicibilityTimeAfterHit = 2f;

    public HealthBar healthBar;
    public SpriteRenderer graphics;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("PlayerHealth already exist on scene");
        }

        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SerMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(60);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvicible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }

            isInvicible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibityDelay());
        }
    }

    public void Die()
    {
        PlayerMouvement.instance.enabled = false;
        PlayerMouvement.instance.animator.SetTrigger("OnPlayerDie");
        PlayerMouvement.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        PlayerMouvement.instance.playerCollider.enabled = false;
    }

    public void Heal(int heal)
    {
        if ((currentHealth + heal) > maxHealth)
        {
            currentHealth = maxHealth;
        } else
        {
            currentHealth += heal;
        }

        healthBar.SetHealth(currentHealth);
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvicible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvicibityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
