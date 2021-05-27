using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killguy : MonoBehaviour
{
    GameObject god;
    controller controller;
    // Start is called before the first frame update
    void Start()
    {
        god = GameObject.FindGameObjectWithTag("god");
        controller = god.GetComponent<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            controller.health -= 1;
        }
        if (collision.tag == "weapon" && this.gameObject.tag != "rock")
        {
            print("I dies");
            controller.score += 1;
            transform.parent.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
