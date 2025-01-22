using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Boss;
    public Vector3 move;
    Vector3 addforce;
    // Start is called before the first frame update
    void Start()
    {
        addforce = move;
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.tag == "Boss01")
        {
            transform.Translate(0.0f, addforce.y, 0.0f);
            if(transform.position.y > 3 && addforce.y > 0)
            {
                addforce.y = addforce.y * 0.98f;
                if (transform.position.y > 4)
                {
                    addforce = move;
                    addforce.y *= -1;
                }
            }
            else if(transform.position.y < -3 && addforce.y < 0)
            {
                addforce.y = addforce.y * 0.98f;
                if (transform.position.y < -4)
                {
                    addforce = -move;
                    addforce.y *= -1;
                }
            }
        }
        else
        {

        }
    }
}
