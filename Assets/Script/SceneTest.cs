using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTest : MonoBehaviour
{
    public GameObject player;   // ユニティちゃんを格納する変数
    public GameObject text;     // テキストを格納するための変数
    private RestartManager restart;

    // Start is called before the first frame update
    void Start()
    {
        restart = new RestartManager(player, text);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&restart.IsGameClear())
        {
            restart.Restart();
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            restart.IsGameClear();
            restart.PrintGameClear();
        }
    }
}
