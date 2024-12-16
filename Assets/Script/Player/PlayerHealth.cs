using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject panelDead;

    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false; // Cờ bất tử
    public float invincibleDuration = 1f; // Thời gian bất tử
    public float blinkInterval = 0.1f; // Tần suất nhấp nháy

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeallth(currentHealth);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isInvincible)
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Heal"))
        {
            Destroy(collision.gameObject);
            Heal(2);
        }
        if (collision.gameObject.CompareTag("TankBullet") && !isInvincible)
        {
            TakeDamage(5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && !isInvincible)
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Boss") && !isInvincible)
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("TankBullet") && !isInvincible)
        {
            TakeDamage(5);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            Debug.Log("DEAD");
            Time.timeScale = 0f;
            this.GetComponent<PlayerShooting>().enabled = false;
            panelDead.SetActive(true);
        }
        else
        {
            StartCoroutine(InvincibilityEffect());
        }
    }

    public void Heal(int heal)
    {
        Debug.Log("=====================>HEAL");
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    public void DeathZone()
    {
        TakeDamage(currentHealth);
    }

    private IEnumerator InvincibilityEffect()
    {
        isInvincible = true; // Kích hoạt trạng thái bất tử

        float elapsedTime = 0f;
        while (elapsedTime < invincibleDuration)
        {
            // Nhấp nháy Sprite
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);

            elapsedTime += blinkInterval;
        }

        spriteRenderer.enabled = true; // Đảm bảo Sprite bật lại sau khi nhấp nháy
        isInvincible = false; // Hủy trạng thái bất tử
    }
}
