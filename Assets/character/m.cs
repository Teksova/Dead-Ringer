using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject god;
    Rigidbody2D phys;
    Vector2 speedForce;
    Vector2 friction;
    Vector2 pos;
    int test;
    int direction, jumpReady, throttle;
    public List<Vector2> record;
    public bool startrecording;
    public bool alive;
    bool death;
    void Start()
    {
        god = GameObject.FindGameObjectWithTag("god");
        phys = GetComponent<Rigidbody2D>();
        speedForce = new Vector2(7f, 0);
        friction = new Vector2(7f, 0);
        direction = 1;
        jumpReady = 1;
        throttle = 0;
        startrecording = true;
        alive = true;
        record = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == false)
        {
            this.gameObject.SetActive(false);
        }

        // Left Right Movement
        if (Input.GetAxis("Horizontal") > 0 && phys.velocity.x <= 15f)
        {
            //phys.AddForce(speedForce, ForceMode2D.Force);
            phys.velocity = new Vector2(10f, phys.velocity.y);
            direction = 1;
            if(Input.GetAxis("Fire3") > 0)
            {
                phys.velocity = new Vector2(20f, phys.velocity.y);
            }
        }
        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x >= -15f)
        {
            //phys.AddForce(-speedForce, ForceMode2D.Force);
            phys.velocity = new Vector2(-10f, phys.velocity.y);
            direction = 0;
            if (Input.GetAxis("Fire3") > 0)
            {
                phys.velocity = new Vector2(-20f, phys.velocity.y);
            }
        }

        if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x > 0)
        {
            if(throttle > 10)
            {
                if (phys.velocity.x != 0)
                {
                    phys.velocity = new Vector2(phys.velocity.x - 1f, phys.velocity.y);
                }
            }
        }

        if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x < 0)
        {
            if (throttle > 10)
            {
                if (phys.velocity.x != 0)
                {
                    phys.velocity = new Vector2(phys.velocity.x + 1f, phys.velocity.y);
                }
            }
        }
        //Friction
        /*if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x > 0)
        {
            phys.AddForce(-friction, ForceMode2D.Force);
        }

        if (Input.GetAxis("Horizontal") == 0 && phys.velocity.x < 0)
        {
            phys.AddForce(friction, ForceMode2D.Force);
        }
        */
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

        //Jump
        if (Input.GetAxis("Jump") > 0 && jumpReady == 1)
        {
            phys.velocity = new Vector2 (phys.velocity.x, 20f);
            jumpReady = 0;
        }
        
        //Jump Reset
        if (phys.velocity.y == 0)
        {

            if(jumpReady < 1)
            {
                jumpReady += 1;
            }

        }

        if (throttle > 10 && startrecording==true)
        {

            pos = phys.position;
            record.Add(pos);
            throttle = 0;

        }
        throttle += 1;
        //print(record.Count);
        //print(startrecording);
      
    }
}


