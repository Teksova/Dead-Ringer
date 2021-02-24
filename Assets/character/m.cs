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
    public int left, right;
    public List<int> record;
    void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        speedForce = new Vector2(7f, 0);
        friction = new Vector2(4f, 0);
        direction = 1;
        jumpReady = 1;
        record = new List<int>();
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
        }
        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x >= -15f)
        {
            phys.AddForce(-speedForce, ForceMode2D.Force);
            direction = 0;
            left += 1;
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
                record.Add(right);
                right = 0;
            }
            else
            {
                record.Add(left);
                left = 0;
            }
            record.Add(123456789);
            jumpReady = 0;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            if (direction == 1)
            {
                record.Add(right);
                right = 0;
            }
            else
            {
                record.Add(left);
                left = 0;
            }
        }
        
        print(record);
        if (phys.velocity.y == 0)
        {
            if(jumpReady < 1)
            {
                jumpReady += 1;
            }
        }
    }
}

