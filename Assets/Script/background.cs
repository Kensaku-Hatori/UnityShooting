using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed;             //�X�N���[���̃X�s�[�h
    public float limit;             //��ʉE�[���炢�Ȃ��Ȃ���W

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
