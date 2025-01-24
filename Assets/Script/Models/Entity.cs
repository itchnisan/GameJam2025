using UnityEngine;
using Assets.Script.Models;

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

        [Header("Attacks")]
        public AttackBall attackBall;


        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }

            //TODO knockback
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}