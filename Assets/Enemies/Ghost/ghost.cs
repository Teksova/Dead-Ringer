using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{

    public GameObject man;
    m script;
    List<Vector2> movements;
    Rigidbody2D self;
    Vector3 placeholder;

    public bool go;
    int count, modifier;
    Vector3 manPosition;
    Vector3 ghostPosition;
    bool agroGhost1 = false;
    float angle;
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
        //get positions for agro ghost mode
        manPosition = man.transform.position;
        ghostPosition = this.transform.position;

        if (go == false && script.startrecording == true)
        {
            this.gameObject.SetActive(false);
        }
        if (go == true && !agroGhost1)
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

            if (manPosition.x < ghostPosition.x)
            {
                agroGhost1 = true;
            }
        }
        
        if (agroGhost1)
        {
            //no clip charge the player
            StartCoroutine(dashtest());
           

            //damage the player

            //recoil on damage

            //return to normal mode
            if (manPosition.x > ghostPosition.x)
            {
                agroGhost1 = false;
            }
        }
                
    }
    IEnumerator dashtest()
    {
        placeholder = transform.position;

        self.velocity = new Vector2(0, 7f);
        yield return new WaitForSeconds(0.25f);
        Vector3 point = manPosition - transform.position;
        angle = Mathf.Atan2(point.y, point.x);
        if (Mathf.Cos(angle) < 0)
        {
            modifier = -2;
        }
        if (Mathf.Cos(angle) > 0)
        {
            modifier = 2;
        }
        self.velocity = new Vector2(Mathf.Cos(angle) * 12, Mathf.Sin(angle) * 12 + modifier);
        yield return new WaitForSeconds(0.5f);
        self.velocity = new Vector2(2f, 0);

        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(transform.position.x, placeholder.y, transform.position.z);

    }

}


