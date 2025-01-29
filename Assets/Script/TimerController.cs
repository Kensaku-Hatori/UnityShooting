using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI Timer; // Text�I�u�W�F�N�g
    public int TimerLimit; // �X�R�A�ϐ�
    float time;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer = TimerLimit - time;
        Timer.SetText("TIMELIMIT:" + (timer.ToString("n1")));
        if(timer <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
