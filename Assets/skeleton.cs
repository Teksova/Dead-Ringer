using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    GameObject sword;
    Rigidbody2D self;
    int count, countmax;
    int direc, direcstore;
    bool swinging;
    Vector3 swordpos;
    // Start is called before the first frame update
    void Start()
    {
        countmax = 150;
        direc = 1;
        count = 0;
        swinging = false;
        sword = transform.GetChild(0).gameObject;
        self = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(swinging == false)
        {
            count += 1;
            if (count > countmax && direc == 1)
            {
                self.velocity = new Vector2(5f, 0f);
                count = 0;
                direcstore = direc;
                direc = 0;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (count > countmax && direc == 2)
            {
                self.velocity = new Vector2(-5f, 0f);
                count = 0;
                direcstore = direc;
                direc = 0;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (count > 500 && direc == 0)
            {
                self.velocity = new Vector2(0f, 0f);
                count = 0;
                if (direcstore == 1)
                {
                    direc = 2;
                }
                else
                {
                    direc = 1;
                }
            }
        }
        
    }

    IEnumerator swing()
    {
        print("kill move");
        swinging = true;
        if(transform.rotation.y == 0)
        {
            self.velocity = new Vector2(5f, 0f);
        }
        if(transform.rotation.y == 180)
        {
            self.velocity = new Vector2(-5f, 0f);
        }
        yield return new WaitForSeconds(.1f);
        sword.gameObject.SetActive(true);
        if (transform.rotation.y == 0)
        {
            self.velocity = new Vector2(-15f, 0f);
        }
        if (transform.rotation.y == 180)
        {
            self.velocity = new Vector2(15f, 0f);
        }
        yield return new WaitForSeconds(.25f);
        sword.gameObject.SetActive(false);
        self.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(.25f);
        sword.gameObject.SetActive(true);
        if (transform.rotation.y == 0)
        {
            self.velocity = new Vector2(-15f, 0f);
        }
        if (transform.rotation.y == 180)
        {
            self.velocity = new Vector2(15f, 0f);
        }
        yield return new WaitForSeconds(.25f);
        sword.SetActive(false);
        self.velocity = new Vector2(0f, 0f);
        swinging = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && swinging == false)
        {
            swinging = true;
            StartCoroutine(swing());
        }
    }
}
