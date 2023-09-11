using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPXFollowing : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Tính toán hướng di chuyển từ NPC đến nhân vật
        //Vector3 direction = playerTransform.position - transform.position;
        //direction.Normalize();

        //transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
