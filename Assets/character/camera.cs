using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject man;
    GameObject cam;
    Vector3 manPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        manPos = man.transform.position;


            if (transform.position.x <= manPos.x - 2)
            {
                manPos.z = manPos.z - 30;
                manPos.y = transform.position.y;
                manPos.x = manPos.x - 2;
                transform.position = manPos;
            }
            if (transform.position.x >= manPos.x + 2)
            {
                manPos.z = manPos.z - 30;
                manPos.y = transform.position.y;
                manPos.x = manPos.x + 2;
                transform.position = manPos;
            }


    }
}
