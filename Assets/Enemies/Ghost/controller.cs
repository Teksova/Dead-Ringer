using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    GameObject maincanvas, man;
    public int maxH, health;
    // Start is called before the first frame update
    void Start()
    {
        maxH = health = 3;
        maincanvas = GameObject.FindGameObjectWithTag("canvas");
        man = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 2)
        {
            maincanvas.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (health == 1)
        {
            maincanvas.transform.GetChild(1).gameObject.SetActive(false);
        }
        if(health == 0)
        {
            maincanvas.transform.GetChild(0).gameObject.SetActive(false);
            man.SetActive(false);
        }
    }
}
