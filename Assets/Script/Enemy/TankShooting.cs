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

    void Start()
    {
        showShootPoint.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.transform.position);
        /* Debug.Log("+>"+ distance);*/
        if (distance < shootRange)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                shoot();
            }

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
    }
}
