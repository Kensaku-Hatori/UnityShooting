using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        if(Input.GetMouseButtonDown(0)&&loadScene.name == "TitleScene")
        {
            SceneManager.LoadScene("GameScene");
        }
        else if (Input.GetMouseButtonDown(0) && loadScene.name == "ResultScene")
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
