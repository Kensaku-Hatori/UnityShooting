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
        AIM,            // プレイヤーを狙う
        THREE_WAY,      // ３方向
    }

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public ShotType type;
        public EnemyBullet bullet;
    }

    // ショットデータ

    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.THREE_WAY, bullet = null };

    GameObject playerObj = null;    // プレイヤーオブジェクト
    int shotFrame = 0;              // フレーム

    public float speed = -2.0f;

    void Start()
    {
        nHP = 50;
        color = GetComponent<Renderer>();
        color.material.color = new Color(1, 1, 1, 1);

        // プレイヤーオブジェクトを取得する
        switch (shotData.type)
        {
            case ShotType.AIM:
                playerObj = GameObject.Find("player");
                break;
        }
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                // プレイヤーを狙う
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

                // ３方向
                case ShotType.THREE_WAY:
                    {
                        //弾
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
        color.material.color = new Color(1, 0, 0, 1); //赤
        yield return new WaitForSeconds(0.5f);
        color.material.color = new Color(1, 1, 1, 1); //白
    }

}
