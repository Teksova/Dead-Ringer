using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class controller : MonoBehaviour
{
    GameObject maincanvas, man, text;
    TMP_Text realtext;
    public int maxH, health;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        maxH = health = 3;
        maincanvas = GameObject.FindGameObjectWithTag("canvas");
        man = GameObject.FindGameObjectWithTag("Player");
        text = maincanvas.transform.GetChild(4).gameObject;
        realtext = text.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (health == 2)
        {
            maincanvas.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (health == 1)
        {
            maincanvas.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (health == 0)
        {
            maincanvas.transform.GetChild(0).gameObject.SetActive(false);
            man.SetActive(false);
        }
        realtext.text = score.ToString();
    }
}
