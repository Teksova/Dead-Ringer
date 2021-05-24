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
            if (count == 0)
            {
                countmax = Random.Range(50, 300);
            }
            print(countmax);
            count += 1;
            if (count > countmax && direc == 1)
            {
                self.velocity = new Vector2(5f, 0f);
                count = 0;
                direcstore = direc;
                direc = 0;
            }
            if (count > countmax && direc == 2)
            {
                self.velocity = new Vector2(-5f, 0f);
                count = 0;
                direcstore = direc;
                direc = 0;
            }
            if (count > 300 && direc == 0)
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
        swinging = true;
        self.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(.5f);
        sword.transform.Rotate(0f,0f,-25f);
        if(direc == 1)
        {
            self.velocity = new Vector2(-10f, 0f);
        }
        if(direc == 2)
        {
            self.velocity = new Vector2(10f, 0f);
        }
        yield return new WaitForSeconds(.25f);
        sword.transform.Rotate(0f, 0f, 100f);
        if (direc == 1)
        {
            self.velocity = new Vector2(10f, 0f);
        }
        if (direc == 2)
        {
            self.velocity = new Vector2(-10f, 0f);
        }
        yield return new WaitForSeconds(1f);
        sword.transform.Rotate(0f, 0f, -50.995f);
        swinging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && swinging == false)
        {
            swing();
        }
    }
}
