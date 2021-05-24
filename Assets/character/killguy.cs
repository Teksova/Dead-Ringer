using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killguy : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "weapon")
        {
            print("I dies");
            transform.parent.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
