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
            transform.position = new Vector3(manPos.x - 2, manPos.y, transform.position.z);
        }
        if (transform.position.x >= manPos.x + 2)
        {

            transform.position = new Vector3(manPos.x + 2, manPos.y, transform.position.z);
        }
        
        if (transform.position.y <= manPos.y - 2)
        {
            transform.position = new Vector3(manPos.x, manPos.y - 2, transform.position.z);
        }
        if (transform.position.y >= manPos.y + 2)
        {
            transform.position = new Vector3(manPos.x, manPos.y + 2, transform.position.z);
        }



    }
}
