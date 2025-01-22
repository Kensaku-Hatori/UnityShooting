using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartManager : MonoBehaviour
{
    private GameObject player;
    private GameObject text;
    private bool isGameOver = false;
    private bool isGameClear = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public RestartManager(GameObject player, GameObject text)
    {
        this.player = player;
        this.text = text;
    }
    public void PrintGameOver()
    {
        // ゲームオーバーを表示する
        text.GetComponent<TextMeshProUGUI>().text = "GameOver\nClick or Enter";
        text.SetActive(true);
        // ゲームオーバー
        isGameOver = true;
    }
    public void PrintGameClear()
    {
        // ゲームオーバーを表示する
        text.GetComponent<TextMeshProUGUI>().text = "GameClear\nClick or Enter";
        text.SetActive(true);
        // ゲームクリアー
        isGameClear = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("ResultScene");     // Sceneの読み直し
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameClear()
    {
        return isGameClear;
    }
}
