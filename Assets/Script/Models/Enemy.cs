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
            Debug.Log("quoicoube1");
            if (other.CompareTag("PlayerAttack"))
            {
                PlayerCharacter player = other.GetComponentInParent<PlayerCharacter>();
                Rigidbody2D rb = other.GetComponentInParent<Rigidbody2D>();
                if(rb == null) {
                    TakeDamage(player.attackBall);
                    Debug.Log("rb null");
                }
                
                if(player == null) {
                    Debug.Log("player null");
                }
                else {
                TakeDamage(player.attackBall,rb.linearVelocity);
                }
                
                
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
