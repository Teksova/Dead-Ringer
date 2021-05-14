using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{

    public GameObject man;
    m script;
    List<Vector2> movements;
    Rigidbody2D self;
    public bool go;
    int count;
    // Start is called before the first frame update
    void Start()
    { 
        self = GetComponent<Rigidbody2D>();
        script = man.GetComponent<m>();
        movements = script.record;
        go = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (go == false && script.startrecording == true)
        {
            this.gameObject.SetActive(false);
        }
        if (go == true)
        {
            script.startrecording = false;
            if (count == 10)
            {
                self.position = movements[0];
                movements.Remove(movements[0]);
                count = 0;
                if (movements.Count == 0)
                {
                    go = false;
                    script.startrecording = true;
                }
            }
            count += 1;
        }
    }
}
