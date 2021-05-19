using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostcontrol : MonoBehaviour
{
    public GameObject ghost;
    ghost script;
    // Start is called before the first frame update
    void Start()
    {
        script = ghost.GetComponent<ghost>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") == 1 && script.go == false)
        {
            ghost.SetActive(true);
            script.go = true;
        }
    }
}
