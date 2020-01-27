using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code was supported by the help of the tutorial https://www.awesomeinc.org/tutorials/unity-pong/
public class MoveBall : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public static int ballCount;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2);
        ballCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //starts the game by producing movement left or right 
    void StartBall()
    {
        ballCount = ballCount / 2;
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    //Resets the ball to its initial position
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    //Invoked when the ball hits a dead wall
    void RestartGame()
    {
        ResetBall();
        Invoke("StartBall", 1);
    }

    //Changes direction of the ball based on its speed and position on the paddle
    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            
            ballCount++;
            if (ballCount % 5 == 0)
            {
                Debug.Log("ballcount met ...");
                vel.x = (rb2d.velocity.x + 5);
            }
            rb2d.velocity = vel;

        }
    }
}
