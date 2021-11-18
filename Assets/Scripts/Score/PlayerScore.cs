using System;
using SnakeBody;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class PlayerScore : MonoBehaviour
    {
        private int _bodyCount;
        private float _scoreCount = 0;

        public Text bodyCountLog;
        public Text scoreCountLog;
        
        //public Text highScoreLog;

        private void Start()
        {
            UpdateGUI(); //updates interface with current score/ gained body size.
            //highScoreLog.text = "High Score: " + PlayerPrefs.GetFloat("high score"); //gives the player current high score.
        }

        public void Update()
        {
            if (AddToBody.addToScore)
            {
                AddToBody.addToScore = false;
                _scoreCount += 100;
                _scoreCount *= 1.1f;
                _bodyCount++;
                UpdateGUI();
            }

            if (PlayerPrefs.GetFloat("high score") <= _scoreCount)
            {
                HighScore();
            }
        }

        private void UpdateGUI()
        {
            bodyCountLog.text = "Body size: " + _bodyCount;
            scoreCountLog.text = "Score: " + Math.Round(_scoreCount); //rounds the score count to whole numbers into gui.
        }

        private void HighScore()
        {
            PlayerPrefs.SetFloat("high score", (float) Math.Round(_scoreCount)); //stores local high score and round it.
        }
    
    }
}