
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : MonoBehaviour
{
    public Sprite batA;
    public Sprite batB;
    public GameObject player;
    Vector3 placeholder;
    Rigidbody2D self;
    int count, modifier;
    bool dashstart, dashing, idle;
    int sprite;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Rigidbody2D>();
        count = 0;
        dashing = false;
        dashstart = false;
        idle = true;
        modifier = 0;
        sprite = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (count > 30 && idle == true)
        {
            self.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            count = 0;
            spriteflip();
            if (sprite == 1)
            {
                 this.gameObject.GetComponent<SpriteRenderer>().sprite = batA;
            }

            if (sprite == 2)
            {
                 this.gameObject.GetComponent<SpriteRenderer>().sprite = batB;
            }
        }
        if (dashing == true)
        {
            print("go");
            idle = false;
            dashing = false;
            StartCoroutine(dashtest());
        }
        count += 1;
    }

    void OnTriggerStay2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            if (dashstart == false)
            {
                dashing = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            dashing = false;
            count = 0;
        }
    }

    void spriteflip()
    {
        sprite += 1;
        if (sprite > 2)
        {
            sprite = 1;
        }
    }
    IEnumerator dashtest()
    {
        placeholder = transform.position;
        dashstart = true;
        self.velocity = new Vector2(0, 7f);
        yield return new WaitForSeconds(0.25f);
        Vector3 point = player.transform.position - transform.position;
        angle = Mathf.Atan2(point.y, point.x);
        if(Mathf.Cos(angle) < 0)
        {
            modifier = -2;
        }
        if (Mathf.Cos(angle) > 0)
        {
            modifier = 2;
        }
        self.velocity = new Vector2(Mathf.Cos(angle) * 12, Mathf.Sin(angle) * 12 + modifier);
        yield return new WaitForSeconds(0.5f);
        self.velocity = new Vector2(2f, 0);
        idle = true;
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(transform.position.x, placeholder.y, transform.position.z);
        dashstart = false;
    }
}
