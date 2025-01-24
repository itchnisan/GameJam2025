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
        public float run;

        public Vector2 targetPosition;


        [Header("States")]
        public bool stun = false;
        public bool inFire = false;
        public bool test = true;

        [Header("References")]

        public GameObject bulletPrefab;
    
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