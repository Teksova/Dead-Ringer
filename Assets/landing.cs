using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landing : MonoBehaviour
{
    m m;

    // Start is called before the first frame update
    void Start()
    {
        m = transform.GetComponentInParent<m>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        print("toes");
        print(collision.tag);
        if(collision.tag == "ground")
        {
            m.jumpready = true;
        }
    }
}
