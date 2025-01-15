using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3.0f;                   // ˆÚ“®’l
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);  // ˆÚ“®•ûŒü

    // Update is called once per frame
    void Update()
    {
        float add_move = moveSpeed * Time.deltaTime;
        transform.Translate(moveVec * add_move);
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    public void SetMoveVec(Vector3 _Vec)
    {
        moveVec = _Vec.normalized;
    }

    enum@ShotType
    {
        NONE=0,
        AIM,
    }

    [System.Serializable]
    struct ShotData
    {
        public int frame;
        public ShotType type;
        public Enemy bullet;
    }

    [SerializeField] ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

    GameObject playerObj = null;
    int shotFrame = 0;

    void Start()
    {
        switch(shotData.type)
        {
            case ShotType.AIM:
                playerObj = GameObject.Find("player");
                break;
        }
    }

    void Shot()
    {
        ++shotFrame;
        if(shotFrame>shotData.frame)
        {
            switch(shotData.type)
            {
                case ShotType.AIM:
                    {
                        if (playerObj == null) { break; }
                        Enemy bullet = (Enemy)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity);
                        bullet.SetMoveVec(playerObj.transform.position - transform.position);
                    }
                    break;
            }
            shotFrame = 0;
        }
    }
}
