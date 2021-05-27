using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thetoecodeTM : MonoBehaviour
{
    Rigidbody2D parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        print("toetime");
        parent.velocity = new Vector2(0f, 0f);
    }
}
