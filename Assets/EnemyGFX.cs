using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class EnemyGFX : MonoBehaviour
{
    private Animator anim;
    public AIPath aiPath;
    private SpriteRenderer sprite;
    private int stack;
    public int diePoint;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hurt")
        {
            stack++;
            //anim.SetTrigger("EnemyHurt");
            if (stack == diePoint)
            {

                if (gameObject.tag == "Boss")
                {
                    var player = GameObject.FindGameObjectsWithTag("Player");
                    ItemCollector itemCollector = player[0].gameObject.GetComponent<ItemCollector>();
                    itemCollector.onIncrementScore(10);
                    itemCollector.UpdateScoreText();
                    Destroy(gameObject);



                }
                else
                {
                    var player = GameObject.FindGameObjectsWithTag("Player");
                    ItemCollector itemCollector = player[0].gameObject.GetComponent<ItemCollector>();
                    itemCollector.onIncrementScore(5);
                    itemCollector.UpdateScoreText();
                    Destroy(gameObject);

                }
            }
            else
            {
                return;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale= new Vector3(-1f ,1f ,1f);
        }else if(aiPath.desiredVelocity.x <= 0.01f)
                {

            transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }
}
