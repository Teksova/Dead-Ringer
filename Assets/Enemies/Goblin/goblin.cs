using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    Rigidbody2D self;
    GameObject rock;
    Vector3 rockpos1, rockpos2, rockpos3;
    public Sprite throwA, throwB, throwC;
    public GameObject player;
    int direction, count;
    int modifier;
    float angle;
    bool throwing;
    // Start is called before the first frame update
    void Start()
    {

        rock = transform.GetChild(1).gameObject;
        self = GetComponent<Rigidbody2D>();
        direction = 1;
        count = 0;
        throwing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (throwing == false)
        {
            if (count > 300 && direction == 1)
            {
                self.velocity = new Vector2(5f, 0);
                count = 0;
                direction = 2;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (count > 300 && direction == 2)
            {
                self.velocity = new Vector2(-5f, 0);
                count = 0;
                direction = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        count += 1;
    }
    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (throwing == false)
            {
                throwing = true;
                StartCoroutine(throwrock());
            }
        }
    }
    
    IEnumerator throwrock()
    {
        rock.gameObject.SetActive(true);
        rock.transform.GetChild(0).gameObject.SetActive(true);
        rockpos1 = rock.transform.position;
        self.velocity = new Vector2(0, 0);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = throwB;
        if (direction == 1)
        {
            rockpos2 = new Vector3(transform.position.x + 1.048f, transform.position.y + 1.208f, 0);
        }
        if (direction == 2)
        {
            rockpos2 = new Vector3(transform.position.x - 1.048f, transform.position.y + 1.208f, 0);
        }
        rock.transform.position = rockpos2;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = throwC;
        Vector3 point = player.transform.position - transform.position;
        angle = Mathf.Atan2(point.y, point.x);
        if (Mathf.Cos(angle) < 0)
        {
            modifier = -2;
        }
        if (Mathf.Cos(angle) > 0)
        {
            modifier = 2;
        }
        rock.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle) * 20, Mathf.Sin(angle) * 20 + modifier);
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = throwA;
        rock.transform.position = rockpos1;
        throwing = false;
    }
    
}
