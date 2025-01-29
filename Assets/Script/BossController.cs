using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BulletPrefab;
    public Vector3 move;
    public int ActionCoolDown;
    public int tacklspeed;
    Vector3 addforce;
    int nCount,Action,OldAction;
    bool bAction;
    int nHP;
    // Start is called before the first frame update
    void Start()
    {
        bAction = false;
        nCount = 0;
        Action = 0;
        addforce = move;
        nHP = 10;
    }

    // Update is called once per frame
    void Update()
    {
        nCount++;
        if(nCount >= ActionCoolDown && bAction == false)
        {
            ActionUpdate();
        }
        BossMove();
    }
    void BossMove()
    {
        if (Boss.tag == "Boss01")
        {
            transform.Translate(addforce.x, addforce.y, 0.0f);
            if(bAction == true && transform.position.x < -7)
            {
                addforce.x = 0.1f;
            }
            else if(bAction == true && transform.position.x > 7)
            {
                bAction = false;
                addforce.x = 0.0f;
                addforce.y = move.y;
            }
            if (transform.position.y > 3 && addforce.y > 0)
            {
                addforce.y = addforce.y * 0.98f;
                if (transform.position.y > 4)
                {
                    addforce.y = move.y;
                    addforce.y *= -1;
                }
            }
            else if (transform.position.y < -3 && addforce.y < 0)
            {
                addforce.y = addforce.y * 0.98f;
                if (transform.position.y < -4)
                {
                    addforce.y = -move.y;
                    addforce.y *= -1;
                }
            }
        }
        else
        {

        }
    }
    void ActionUpdate()
    {
        nCount = 0;
        OldAction = Action;
        Action = (int)Random.Range(0.0f, 3.0f);
        if (OldAction == 2 && Action == 2)
        {

        }
        else
        {
            switch (Action)
            {
                case 0:
                    Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 0.75f));
                    Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 1.0f));
                    Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 1.25f));
                    break;
                case 1:
                    bAction = true;
                    addforce.x = -0.1f;
                    addforce.y = 0.0f;
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nHP--;
            if (nHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
