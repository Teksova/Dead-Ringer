using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    GameObject Spear;
    GameObject self;
    Rigidbody2D spear;
    EdgeCollider2D spearEdge;
    bool swinging;

    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        Spear = this.transform.GetChild(0).gameObject;
        spear = Spear.GetComponent<Rigidbody2D>();
        spearEdge = Spear.GetComponent<EdgeCollider2D>();
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
        if(swinging == true)
        {
            //Spear.transform.position = Spear.transform.position
        }
    }

    IEnumerator attack()
    {
        swinging = true;
        spearEdge.enabled = false;
        //spear.velocity = new Vector2(-2f, 0);
        Spear.transform.Translate(-1f, -1f, 0);
        yield return new WaitForSeconds(.5f);
        spearEdge.enabled = true;
        Spear.transform.Translate(2f, 2f, 0);
        //spear.velocity = new Vector2(10f, 0);
        yield return new WaitForSeconds(.5f);
        //spear.velocity = new Vector2(0f, 0f);
        spear.transform.position = new Vector3(self.transform.position.x + .89f, self.transform.position.y +.08f, Spear.transform.position.z);
        Spear.SetActive(false);
        swinging = false;
    }
}
