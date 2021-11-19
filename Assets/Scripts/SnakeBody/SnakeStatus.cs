using System;
using UnityEngine;

namespace SnakeBody
{
    public class SnakeStatus : MonoBehaviour
    {
        public int totalHealth = 5;
        private int currentHealth;
        public static bool isDead;
        

        public void Start()
        {
            currentHealth = totalHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                Destroy(this);
            }
        }


    }
}
