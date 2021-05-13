using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D phys;
    Vector2 speedForce;
    Vector2 friction;
    int direction;
    int jumpReady;
    int left, right;
    bool onlyonce;
    public List<int> recordTime;
    public List<string> direcs;
    void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        speedForce = new Vector2(7f, 0);
        friction = new Vector2(4f, 0);
        direction = 1;
        jumpReady = 1;
        recordTime = new List<int>();
        direcs = new List<string>();
        onlyonce = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Left Right Movement
        if (Input.GetAxis("Horizontal") > 0 && phys.velocity.x <= 15f)
        {
            phys.AddForce(speedForce, ForceMode2D.Force);
            direction = 1;
            right += 1;
            onlyonce = true;
        }
        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x >= -15f)
        {
            phys.AddForce(-speedForce, ForceMode2D.Force);
            direction = 0;
            left += 1;
            onlyonce = true;
        }

        //Friction
        if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x > 0)
        {
            phys.AddForce(-friction, ForceMode2D.Force);
        }

        if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x < 0)
        {
            phys.AddForce(friction, ForceMode2D.Force);
        }

        //Extra slowing to reduce floaty feel
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (phys.velocity.x > -.3 && phys.velocity.x < .3)
            {
                phys.velocity = new Vector2(0f, phys.velocity.y);
            }
        }

        //Max Speed
        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x < -15f)
        {
            phys.velocity = new Vector2(-15f, phys.velocity.y);
        }

        if (Input.GetAxis("Horizontal") > 0 && phys.velocity.x > 15f)
        {
            phys.velocity = new Vector2(15f, phys.velocity.y);
        }

        if (Input.GetAxis("Jump") > 0 && jumpReady == 1)
        {
            phys.velocity = new Vector2 (phys.velocity.x, 10f);
            if (direction == 1)
            {
                recordTime.Add(right);
                direcs.Add("right");
                right = 0;
            }
            else
            {
                recordTime.Add(left);
                direcs.Add("left");
                left = 0;
            }
            direcs.Add("jump");
            recordTime.Add(1);
            jumpReady = 0;
        }

        if (Input.GetAxis("Horizontal") == 0 && onlyonce == true)
        {
            if (direction == 1)
            {
                recordTime.Add(right);
                direcs.Add("right");
                right = 0;
            }
            else
            {
                recordTime.Add(left);
                direcs.Add("left");
                left = 0;
            }
            onlyonce = false;
        }

        print("main" + recordTime.Count);
        print("direcs" + direcs.Count);
        if (phys.velocity.y == 0)
        {
            if(jumpReady < 1)
            {
                jumpReady += 1;
            }
        }
    }
}

