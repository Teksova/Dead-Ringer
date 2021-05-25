using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject Spear;
    Rigidbody2D spear;
    bool swinging;
    // Start is called before the first frame update
    void Start()
    {
        Spear = this.transform.GetChild(0).gameObject;
        spear = Spear.GetComponent<Rigidbody2D>();
        Spear.SetActive(false);
        swinging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && swinging == false)
        {
            Spear.SetActive(true);
            StartCoroutine(attack());
        }
    }
    IEnumerator attack()
    {
        spear.velocity = new Vector2(10f, 0);
        yield return new WaitForSeconds(5f);
        spear.velocity = new Vector2(0, 0);
    }
}
