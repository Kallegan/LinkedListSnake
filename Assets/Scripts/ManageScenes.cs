using System;
using Score;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScenes : MonoBehaviour
{
    public Text highScoreLog;

    private void Awake()
    {
        highScoreLog.text = "High Score: " + PlayerPrefs.GetFloat("high score");
    }

    public void Update()
    {
        if (Triggers.GameOver)
        {
            Invoke(nameof(Menu), 3);
            Triggers.GameOver = false;
        }
    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    
    
    
}
