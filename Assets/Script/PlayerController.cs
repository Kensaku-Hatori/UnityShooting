using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllo : MonoBehaviour
{
    float PlayerSpeed = 0.1f;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�ړ�
        //�㉺
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, PlayerSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -PlayerSpeed, 0);
        }
        //���E
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-PlayerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(PlayerSpeed, 0, 0);
        }

        //�ړ�����
        // X��
        if(transform.position.x <= -8.5f)
        {
            transform.Translate(PlayerSpeed, 0, 0);
        }
        if (transform.position.x >= 8.5f)
        {
            transform.Translate(-PlayerSpeed, 0, 0);
        }
        // Y��
        if (transform.position.y <= -4.5f)
        {
            transform.Translate(0, PlayerSpeed, 0);
        }
        if (transform.position.y >= 4.5f)
        {
            transform.Translate(0, -PlayerSpeed, 0);
        }

        
        //�e
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f,0.0f, Mathf.PI * 0.05f));

            Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 0.0f));

            Instantiate(BulletPrefab, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * -0.05f));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag=="Boss")
        {
            Destroy(gameObject);
        }
    }
}
