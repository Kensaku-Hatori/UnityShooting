using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Boss1;
    public GameObject Boss2;
    private Renderer color;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BossResporn()
    {
        int nBossType = (int)Random.Range(0.0f, 1.0f);

        switch (nBossType)
        {
            case 0:
                Instantiate(Boss1, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 1.0f));
                break;
            case 1:
                Instantiate(Boss2, transform.position, Quaternion.EulerAngles(0.0f, 0.0f, Mathf.PI * 1.0f));
                break;
        }
    }
}
