using System;
using SnakeBody;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class PlayerScore : MonoBehaviour
    {
        private int _bodyCount;
        private float _scoreCount = 0; //made public static for access outside script.

        public Text bodyCountLog; //reference for canvas.
        public Text scoreCountLog;
        
        
        private void Start()
        {
            UpdateGUI(); //updates interface with current score/ gained body size.
        }

        public void Update()
        {
            if (PlayerPrefs.GetFloat("high score") < _scoreCount) //if current score is greater than highscore.
            {
                HighScore(); 
            }
            
            if (AddToBody.addToScore)
            {
                AddToBody.addToScore = false;
                _scoreCount += 100; //gives player 100 score.
                _scoreCount *= 1.1f; //adds 10% extra to total score so score count growth increase the longer you go.
                _bodyCount++; 
                UpdateGUI();
            }
        }

        private void UpdateGUI() //updates interface with new values for text.
        {
            bodyCountLog.text = "Body size: " + _bodyCount;
            scoreCountLog.text = "Score: " + Math.Round(_scoreCount); //rounds the score count to whole numbers into gui.
        }

        private void HighScore() //updates float in playerprefs to set new highscore using current score.
        {
            PlayerPrefs.SetFloat("high score", math.round(_scoreCount)); //stores local high score and round it.
        }
    
    }
}