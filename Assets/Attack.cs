using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject Spear;
    bool swinging;
    // Start is called before the first frame update
    void Start()
    {
        Spear = this.transform.GetChild(0).gameObject;
        Spear.SetActive(false);
        swinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && swinging == false)
        {
            Spear.SetActive(true);
            Invoke("nospear", 0.25f);
            swinging = true;
        }
    }
    void nospear()
    {
        Spear.SetActive(false);
        Invoke("noswing", 0.5f);
    }
    void noswing()
    {
        swinging = false;
    }
}
