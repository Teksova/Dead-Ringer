using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D phys;
    Vector2 speedForce;
    Vector2 friction;
    Vector2 jumpPower;
    int direction;
    int jump;

    void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        speedForce = new Vector2(4f, 0);
        friction = new Vector2(2f, 0);
        jumpPower = new Vector2(0, 100f);
        direction = 1;
        jump = 2;
    }

    // Update is called once per frame
    void Update()
    {

        // Left Right Movement
        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x <= 10f)
        {
            phys.AddForce(speedForce, ForceMode2D.Force);
            direction = 1;
        }

        if (Input.GetAxis("Horizontal") > 0 && phys.velocity.x >= -10f)
        {
            phys.AddForce(-speedForce, ForceMode2D.Force);
            direction = 0;
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
        if (Input.GetAxis("Horizontal") > 0 && phys.velocity.x < -9f)
        {
            phys.velocity = new Vector2(-9f, phys.velocity.y);
        }

        if (Input.GetAxis("Horizontal") < 0 && phys.velocity.x > 9f)
        {
            phys.velocity = new Vector2(9f, phys.velocity.y);
        }

        if (Input.GetAxis("Jump") > 0 && jump == 2)
        {
            phys.AddForce(jumpPower);
        }


    }
}

