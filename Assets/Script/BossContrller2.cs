using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContrller2 : MonoBehaviour
{
    public int nHP;
    private Renderer color;

    enum ShotType
    {
        NONE = 0,
        AIM,            // �v���C���[��_��
        THREE_WAY,      // �R����
    }

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public ShotType type;
        public EnemyBullet bullet;
    }

    // �V���b�g�f�[�^

    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.THREE_WAY, bullet = null };

    GameObject playerObj = null;    // �v���C���[�I�u�W�F�N�g
    int shotFrame = 0;              // �t���[��

    public float speed = -2.0f;

    void Start()
    {
        nHP = 50;
        color = GetComponent<Renderer>();
        color.material.color = new Color(1, 1, 1, 1);

        // �v���C���[�I�u�W�F�N�g���擾����
        switch (shotData.type)
        {
            case ShotType.AIM:
                playerObj = GameObject.Find("player");
                break;
        }
    }

    // �V���b�g�����i�����Update�ȂǂŌĂԁj
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                // �v���C���[��_��
                case ShotType.AIM:
                    {
                        if (playerObj == null) { break; }
                        EnemyBullet bullet = (EnemyBullet)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet.SetMoveVec(playerObj.transform.position - transform.position);
                    }
                    break;

                // �R����
                case ShotType.THREE_WAY:
                    {
                        //�e
                        EnemyBullet bullet = (EnemyBullet)Instantiate(
                        shotData.bullet,
                        transform.position,
                        Quaternion.identity
                        );

                        bullet = (EnemyBullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        bullet = (EnemyBullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                    }
                    break;
            }

            shotFrame = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, speed, 0) * Time.deltaTime;

        if (transform.position.y <= -4.5f)
        {
            speed = -speed;
        }
        if (transform.position.y >= 4.5f)
        {
            speed = -speed;
        }
        Shot();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nHP--;

            StartCoroutine("HitColor");

            if (nHP <= 0)
            {
                StartCoroutine("BossResporn");
                nHP = 50;
            }
        }
    }

    IEnumerator HitColor()
    {
        color.material.color = new Color(1, 0, 0, 1); //��
        yield return new WaitForSeconds(0.5f);
        color.material.color = new Color(1, 1, 1, 1); //��
    }

}
