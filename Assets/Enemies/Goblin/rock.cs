using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    GameObject god;
    controller controller;
    Rigidbody2D self;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject.GetComponent<Rigidbody2D>();
        god = GameObject.FindGameObjectWithTag("god");
        controller = god.GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        //self.AddForce(new Vector2(0, -1f));   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controller.health -= 1;
        }
        print(collision.name);
        gameObject.SetActive(false);
    }
}
