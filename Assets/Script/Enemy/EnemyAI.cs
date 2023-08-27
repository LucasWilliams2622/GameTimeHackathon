using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.TextCore.Text;

public class EnemyAI : MonoBehaviour
{
    public bool roaming = true;
    public float moveSpeed;
    public float nextWPDistance;

    public Seeker seeker;
    public bool updateContinuesPath;

    // shoot 
    public bool isShootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;

    bool reachDestination = false;
    Coroutine moveCoroutine;
    Path path;


    private void Start()
    {
        InvokeRepeating("CaculatePath",0f,0.5f);
        reachDestination = true;
    }
    private void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown < 0)
        {
            fireCooldown = timeBtwFire;
            //Shoot
            EnemyFireBullet();
        }
    }
    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    void CaculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone( )&& (reachDestination || updateContinuesPath))
            seeker.StartPath(transform.position, target, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (p.error) return;
        path = p;
        //Move to target
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }
    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reachDestination = false;
        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
                currentWP++;
            yield return null;
        }

    }
    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<PlayerMovement>().transform.position;
        if (roaming)
        {
            return (Vector2)playerPos + (Random.Range(10f, 50f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
        }
        else
        {
            return playerPos;
        }
    }
}