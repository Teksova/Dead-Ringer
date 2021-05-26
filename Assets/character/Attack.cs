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
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        Spear = this.transform.GetChild(0).gameObject;
        spear = Spear.GetComponent<Rigidbody2D>();
        spearEdge = Spear.GetComponent<EdgeCollider2D>();
        Spear.SetActive(false);
        swinging = false;
        attacking = false;
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
        spear.transform.position = new Vector3(self.transform.position.x + .89f, self.transform.position.y + .08f, Spear.transform.position.z);
        swinging = true;
        attacking = true;
        spearEdge.enabled = false;
        Spear.transform.Translate(-1f, -1f, 0);
        yield return new WaitForSeconds(.25f);
        spearEdge.enabled = true;
        Spear.transform.Translate(1f, 1f, 0);
        yield return new WaitForSeconds(.5f);
        spear.transform.position = new Vector3(self.transform.position.x + .89f, self.transform.position.y +.08f, Spear.transform.position.z);
        Spear.SetActive(false);
        attacking = false;
        yield return new WaitForSeconds(.5f);
        swinging = false;
    }
}
