using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class HighScore : MonoBehaviour
    {
        public Text highScoreLog;
        
        private void Start() //simple highscore that takes stored value in playerpref and displays it at start in menu.
        {
            highScoreLog.text = "High Score: " + PlayerPrefs.GetFloat("high score", (float) 0.00000); 
        }

    }
}
    