using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform Gun;
    Vector2 direction;
    public GameObject Bullet;
    public int MountOfBullet = 0;
    public float BulletSpeed;
    public Transform ShootPoint;
    public TextMeshProUGUI BulletLeftText;
    public GameObject showShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    [SerializeField] private AudioSource sniperSound;
    [SerializeField] private AudioSource chargingSound;
    [SerializeField] private AudioSource outOfBulletSound;
    private int times = 0;
    private bool isRight;
    private bool canShoot = true; // Thêm biến kiểm soát trạng thái bắn

    // Start is called before the first frame update
    void Start()
    {
        showShootPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouce();

        if (Input.GetMouseButtonDown(0) && canShoot) // Kiểm tra trạng thái bắn
        {
            shoot();
        }
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        Debug.Log("=============>" + transform.rotation.z);

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) theScale.y = -1;
        else theScale.y = 1;

        transform.localScale = theScale;
    }

    void showFireShoot()
    {
        showShootPoint.SetActive(true);
        Invoke("hideFireShoot", 0.1f);
    }

    void hideFireShoot()
    {
        showShootPoint.SetActive(false);
    }

    void shoot()
    {
        if (MountOfBullet == 0)
        {
            outOfBulletSound.Play();
            BulletLeftText.text = " " + MountOfBullet;
        }
        else
        {
            sniperSound.Play();
            showFireShoot();

            times++;
            MountOfBullet--;
            BulletLeftText.text = " " + MountOfBullet;

            if (times % 5 == 0)
            {
                Debug.Log("Charging Ammo");
                chargingSound.Play();
            }

            GameObject BulletInstant = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

            BulletInstant.GetComponent<Rigidbody2D>().AddForce(BulletInstant.transform.right * BulletSpeed);
            Destroy(BulletInstant, 2);

            StartCoroutine(ShootingCooldown()); // Gọi Coroutine để chờ 5 giây trước khi bắn tiếp
        }
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false; // Không cho phép bắn
        yield return new WaitForSeconds(5); // Đợi 5 giây
        canShoot = true; // Cho phép bắn lại
    }

    private void FaceMouce()
    {
        Gun.transform.right = direction;
    }
}
