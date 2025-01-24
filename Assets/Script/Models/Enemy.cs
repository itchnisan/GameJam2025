using Models;
using UnityEngine;

namespace Assets.Script.Models
{
    public class Enemy:Entity
    {
        

        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("PlayerAttack"))
            {
                Attack attack = other.GetComponent<Attack>();
                TakeDamage(attack);
                
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                StartCoroutine(base.KnockbackStun());
            }
        }
    }
}
