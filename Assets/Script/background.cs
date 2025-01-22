using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed;             //スクロールのスピード
    public float limit;             //画面右端からいなくなる座標

    // Start is called before the first frame update
    void Start()
    {

    }
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed,0,0);
        if (transform.position.x <= -limit)
        {
            transform.position = new(limit, transform.position.y, transform.position.z);
        }
    }
}
