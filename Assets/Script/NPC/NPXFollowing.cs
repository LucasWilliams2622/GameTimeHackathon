using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPXFollowing : MonoBehaviour
{
    public Transform playerTransform;
    //public float moveSpeed = 5f;
    public float distanceToPlayer;
    public static bool follow;
    public float khoangcachbatdauditheo;
    public Transform ground;
    public static bool jumping;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(playerTransform.transform.position, transform.position);

        //aIDestinationSetter.Target();

        if (jumping)
        {
            Vector3 thePosition = transform.position;
            thePosition.y += 11 * Time.deltaTime;
            transform.position = thePosition;
           
        }
        anim.SetBool("Ground", !jumping);



        // Tính toán hướng di chuyển từ NPC đến nhân vật
        //Vector3 direction = playerTransform.position - transform.position;
        //direction.Normalize();

        //transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
