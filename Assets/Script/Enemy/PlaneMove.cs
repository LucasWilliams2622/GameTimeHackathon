using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float left, right;
    private SpriteRenderer sprite;


    private bool isRight;
    public float speedRun;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 thePosX = transform.position;
        
        if (thePosX.x < left)
        {
            isRight = true;
        }
        if (thePosX.x > right)
        {
            isRight = false;
        }
        if (isRight)
        {
            sprite.flipX = true;
            //transform.Translate(new Vector3(Time.deltaTime * speedRun, 0, 0));
            thePosX.x += speedRun * Time.deltaTime;
        }
        else
        {
            sprite.flipX = false;
            //transform.Translate(new Vector3(-Time.deltaTime * speedRun, 0, 0));
            thePosX.x -= speedRun * Time.deltaTime;

        }

        transform.position = thePosX;


    }
}
