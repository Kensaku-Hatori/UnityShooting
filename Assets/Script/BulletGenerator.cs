using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            GameObject Bullet = Instantiate(BulletPrefab);
            int px = Random.Range(-6, 7);
            Bullet.transform.position = new Vector3(px, 7, 0);
        }
    }
}
