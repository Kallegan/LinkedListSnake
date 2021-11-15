using System;
using Audio;
using UnityEngine;


public class Triggers : MonoBehaviour
{
    public static bool GameOver = false;
    public static bool OutOfBound = false;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("GameOver");
            GameOver = true;
        }
        if(other.tag == "GridArea")
        {
            OutOfBound = true;
        }
    }

}
