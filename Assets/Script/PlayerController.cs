using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllo : MonoBehaviour
{
    float PlayerSpeed = 0.1f;
    public GameObject BulletPrefab;
    public GameObject PlayerPrefab;
    private Renderer color;
    bool bUse;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<Renderer>();
        color.material.color = new Color(1, 1, 1, 1);
        bUse = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (bUse == true)
        {
            //à⁄ìÆ
            //è„â∫
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, PlayerSpeed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, -PlayerSpeed, 0);
            }
            //ç∂âE
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-PlayerSpeed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(PlayerSpeed, 0, 0);
            }

            //à⁄ìÆêßå¿
            // Xé≤
            if (transform.position.x <= -8.5f)
            {
                transform.Translate(PlayerSpeed, 0, 0);
            }
            if (transform.position.x >= 8.5f)
            {
                transform.Translate(-PlayerSpeed, 0, 0);
            }
            // Yé≤
            if (transform.position.y <= -4.5f)
            {
                transform.Translate(0, PlayerSpeed, 0);
            }
            if (transform.position.y >= 4.5f)
            {
                transform.Translate(0, -PlayerSpeed, 0);
            }


            //íe
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 0.05f));

                Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 0.0f));

                Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * -0.05f));
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Boss" || other.gameObject.tag == "Boss01" || other.gameObject.tag == "Boss02")
        {
            StartCoroutine("Resporn");
        }
    }

    private IEnumerator Resporn()
    {
        color.material.color = new Color(1, 1, 1, 0); //ìßñæ
        bUse = false;
        yield return new WaitForSeconds(1.0f);
        color.material.color = new Color(1, 1, 1, 1); //îí
        transform.Translate(-20, 0, 0);
        bUse = true;
    }
}
