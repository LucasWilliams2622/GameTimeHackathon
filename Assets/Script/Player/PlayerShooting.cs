using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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
    private bool canShoot = true;
    private bool isSceneRestricted = false;

    void Start()
    {
        showShootPoint.SetActive(false);

        // Kiểm tra scene hiện tại
        if (SceneManager.GetActiveScene().name == "Level 3 Scene 2")
        {
            isSceneRestricted = true;
        }
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();

        if (Input.GetMouseButtonDown(0) && canShoot) // Kiểm tra trạng thái bắn
        {
            shoot();
        }
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

            if (isSceneRestricted)
            {
                StartCoroutine(ShootingCooldown());
            }
        }
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(5);
        canShoot = true; 
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

    private void FaceMouse()
    {
        Gun.transform.right = direction;
    }
}
