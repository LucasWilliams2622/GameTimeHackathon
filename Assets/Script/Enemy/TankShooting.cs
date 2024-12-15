using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject showShootPoint;

    private float timer;
    private GameObject player;
    public float shootRange;
    [SerializeField] private AudioSource shootSound;

    private bool canShoot = true;

    void Start()
    {
        showShootPoint.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < shootRange && canShoot)
        {
            shoot();
        }
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
        shootSound.Play();
        showFireShoot();
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        StartCoroutine(ShootingCooldown());
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(5);
        canShoot = true; 
    }
}
