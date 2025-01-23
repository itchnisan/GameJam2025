using System;
using UnityEngine;

namespace Models
{
    public class Entity : MonoBehaviour
    {
        [Header("Statistics")]

        public int maxHealth;
        public int health;
        public int damage;
        public float walkSpeed;
        public float runSpeed;



        [Header("States")]
        public bool stun = false;
        public bool inFire = false;
        public bool test = true;



        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {

        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            Console.WriteLine("Update");
            if (Time.time % 3 < Time.deltaTime)
            {
                //TakeDamage(10); // Call TakeDamage every 3 seconds with a damage value of 10
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}