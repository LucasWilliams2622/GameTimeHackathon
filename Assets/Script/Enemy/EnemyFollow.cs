using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject player;
    public float thrownSpace;
    private SpriteRenderer sprite;
    public float followRange;
    private Animator anim;
    [SerializeField] private int stack;
    public int diePoint;
    [SerializeField] private AudioSource hitSound;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FacePlayer();
    }

    private void FacePlayer()
    {
        // Enemy chỉ đổi hướng để nhìn về phía Player
        Vector2 direction = player.transform.position - transform.position;

        // Sử dụng Raycast để kiểm tra có vật cản không
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, followRange);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            // Cập nhật hướng nhìn của Enemy
            sprite.flipX = direction.x < 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.gameObject);
    }

    private void HandleCollision(GameObject other)
    {
        if (other.CompareTag("Hurt"))
        {
            HandleDamage();
        }
        else if (other.CompareTag("TrampolineTop"))
        {
            // Bật Enemy lên khi chạm vào Trampoline
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, thrownSpace);
        }
        else if (other.CompareTag("EnemyDie"))
        {
            // Xóa Enemy nếu chạm vào vùng EnemyDie
            Destroy(gameObject);
        }
    }

    private void HandleDamage()
    {
        hitSound.Play();
        stack++;

        if (stack >= diePoint)
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        // Xóa Enemy khi chết
        Destroy(gameObject);
    }
}
