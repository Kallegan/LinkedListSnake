using System;
using Audio;
using UnityEngine;


public class Triggers : MonoBehaviour
{
    public static bool gameOver; //if game over == true, the game ends.
    public static bool outOfBound; //using to check if the player leaves the grid area.

    private void OnTriggerExit2D(Collider2D other) //checks if the player exits any 2d colliders.
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            gameOver = true;
        }
        if(other.tag == "GridArea")
        {
            outOfBound = true;
        }
    }

}
