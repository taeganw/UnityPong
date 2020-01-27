using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{

    public float speed = 2.0f;
    public float boundY = 4f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;
        if (GameObject.FindGameObjectWithTag("Ball").transform.position.y > GameObject.Find("paddle2").transform.position.y + 0.5)
        {
            vel.y = speed;
        }
        else if (GameObject.FindGameObjectWithTag("Ball").transform.position.y < GameObject.Find("paddle2").transform.position.y - 0.5)
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;

        }


        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
