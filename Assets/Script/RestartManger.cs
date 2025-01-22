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
        // �Q�[���I�[�o�[��\������
        text.GetComponent<TextMeshProUGUI>().text = "GameOver\nClick or Enter";
        text.SetActive(true);
        // �Q�[���I�[�o�[
        isGameOver = true;
    }
    public void PrintGameClear()
    {
        // �Q�[���I�[�o�[��\������
        text.GetComponent<TextMeshProUGUI>().text = "GameClear\nClick or Enter";
        text.SetActive(true);
        // �Q�[���N���A�[
        isGameClear = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("ResultScene");     // Scene�̓ǂݒ���
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
