using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject bullet;                // Đối tượng viên đạn
    public Transform bulletPos;             // Vị trí xuất hiện đạn
    public GameObject showShootPoint;       // Hiệu ứng bắn
    public float shootRange = 10f;          // Phạm vi bắn
    public float shootCooldown = 1f;        // Thời gian chờ giữa các lần bắn

    [Header("Raycast Settings")]
    public LayerMask obstacleLayer;         // Lớp các vật cản (ví dụ: tường)

    [Header("Audio Settings")]
    [SerializeField] private AudioSource shootSound; // Âm thanh bắn

    private float shootTimer;               // Bộ đếm thời gian
    private GameObject player;              // Đối tượng người chơi

    void Start()
    {
        if (bullet == null || bulletPos == null || showShootPoint == null)
        {
            Debug.LogError("EnemyShooting: Missing references! Please assign bullet, bulletPos, and showShootPoint.");
            enabled = false;
            return;
        }

        showShootPoint.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("EnemyShooting: Player not found! Make sure the Player object has the correct tag.");
        }
    }

    void Update()
    {
        if (player == null) return; // Ngăn lỗi nếu không tìm thấy người chơi

        shootTimer += Time.deltaTime;

        // Kiểm tra khoảng cách và Raycast để xem có nhìn thấy người chơi không
        if (CanSeePlayer() && shootTimer >= shootCooldown)
        {
            shootTimer = 0;
            Shoot();
        }
    }

    private bool CanSeePlayer()
    {
        // Tính toán khoảng cách tới người chơi
        Vector2 directionToPlayer = (player.transform.position - bulletPos.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Gửi tia ray từ kẻ địch đến người chơi, kiểm tra va chạm với obstacleLayer
        RaycastHit2D hit = Physics2D.Raycast(bulletPos.position, directionToPlayer, shootRange, obstacleLayer);

        if (hit.collider != null)
        {
            // Nếu tia ray trúng vật cản, kiểm tra xem đó có phải người chơi không
            if (hit.collider.CompareTag("Player"))
            {
                return true; // Có thể bắn
            }
            else
            {
                return false; // Vật cản che khuất
            }
        }

        return false; // Không trúng gì cả
    }

    private void Shoot()
    {
        if (shootSound != null)
            shootSound.Play();

        ShowFireEffect();

        // Sinh viên đạn tại vị trí bulletPos
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    private void ShowFireEffect()
    {
        showShootPoint.SetActive(true);
        Invoke(nameof(HideFireEffect), 0.1f); // Tắt hiệu ứng sau 0.1 giây
    }

    private void HideFireEffect()
    {
        showShootPoint.SetActive(false);
    }
}
