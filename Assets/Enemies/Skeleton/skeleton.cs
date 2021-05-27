using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    GameObject sword;
    Rigidbody2D self;
    int count, countmax;
    int direc, direcstore;
    bool swinging, walking;
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
        if(swinging == false&&walking==false)
        {
            StartCoroutine(patrol());
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

    IEnumerator patrol()
    {
        walking = true;
        if (direc == 1)
        {
            self.velocity = new Vector2(5f, 0);
            count = 0;
            direc = 2;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            self.velocity = new Vector2(-5f, 0);
            count = 0;
            direc = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        yield return new WaitForSeconds(2f);
        self.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        walking = false;
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
