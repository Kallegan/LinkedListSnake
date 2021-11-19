using UnityEngine;
using UnityEngine.SceneManagement;


public class ManageScenes : MonoBehaviour
{
    
    public void Update()
    {
        if (Triggers.gameOver)
        {
            Invoke(nameof(Menu), 2);
            Triggers.gameOver = false;
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
