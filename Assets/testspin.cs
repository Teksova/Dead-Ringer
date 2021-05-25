using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testspin : MonoBehaviour
{
    Rigidbody2D self;
    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        self.angularVelocity = 1000f;
    }
}
