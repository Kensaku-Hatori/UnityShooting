using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContllo : MonoBehaviour
{
    float PlayerSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        //上下
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, PlayerSpeed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -PlayerSpeed, 0);
        }
        //左右
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-PlayerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(PlayerSpeed, 0, 0);
        }

        //移動制限
        // X軸
        if(transform.position.x <= -8.0f)
        {
            transform.Translate(PlayerSpeed, 0, 0);
        }
        if (transform.position.x >= 8.0f)
        {
            transform.Translate(-PlayerSpeed, 0, 0);
        }
        // Y軸
        if (transform.position.y <= -4.5f)
        {
            transform.Translate(0, PlayerSpeed, 0);
        }
        if (transform.position.y >= 4.5f)
        {
            transform.Translate(0, -PlayerSpeed, 0);
        }

    }
}
