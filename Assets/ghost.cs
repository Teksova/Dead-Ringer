using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
<<<<<<< HEAD

    public GameObject man;
    m script;
    List<Vector2> movements;
    Rigidbody2D self;
    public bool go;
    int count;
    // Start is called before the first frame update
    void Start()
    { 
        self = GetComponent<Rigidbody2D>();
        script = man.GetComponent<m>();
        movements = script.record;
        go = false;
=======
    Rigidbody2D phys;
    Vector2 speedForce;
    Vector2 friction;
    public m script;
    List<int> recordTime;
    List<string> direcs;
    bool moving;
    bool next;
    int timekeeper;
    int currentmove;
    // Start is called before the first frame update
    void Start()
    {
        recordTime = script.recordTime;
        direcs = script.direcs;
        speedForce = new Vector2(7f, 0);
        friction = new Vector2(4f, 0);
        phys = GetComponent<Rigidbody2D>();
        currentmove = 0;
        next = false;
>>>>>>> 3b03ccf755c53d08697131e18eccf84587601e06
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (go == false && script.startrecording == true)
        {
            this.gameObject.SetActive(false);
        }
        if (go == true)
        {
            script.startrecording = false;
            if (count == 10)
            {
                self.position = movements[0];
                movements.Remove(movements[0]);
                count = 0;
                if (movements.Count == 0)
                {
                    go = false;
                    script.startrecording = true;
                }
            }
            count += 1;
=======
        if(Input.GetAxis("Fire2") == 1 && moving == false)
        {
            moving = true;
        }
        if(moving == true)
        {
            if (next == true){
                timekeeper = recordTime[currentmove];
                currentmove += 1;
                next = false;
            }
            if(timekeeper == 0)
                if(next == false)
                {
                    if (direcs[currentmove] == "right" && phys.velocity.x <= 15f)
                    {
                        phys.AddForce(speedForce, ForceMode2D.Force);
                    }

                    if (direcs[currentmove] == "left" && phys.velocity.x >= -15f)
                    {
                        phys.AddForce(-speedForce, ForceMode2D.Force);
                    }

                    /*if (direcs[currentmove] == "right" && phys.velocity.x > 0) {
                        phys.AddForce(-friction, ForceMode2D.Force);
                    }

                    if (direcs[currentmove] == "left" && phys.velocity.x < 0)
                    {
                        phys.AddForce(friction, ForceMode2D.Force);
                    }
            */

                    if (phys.velocity.x < -15f)
                    {
                        phys.velocity = new Vector2(-15f, phys.velocity.y);
                    }

                    if (phys.velocity.x > 15f)
                    {
                        phys.velocity = new Vector2(15f, phys.velocity.y);
                    }
            }
            if(recordTime.Count == 0)
            {
                moving = false;
            }
>>>>>>> 3b03ccf755c53d08697131e18eccf84587601e06
        }
    }
}
