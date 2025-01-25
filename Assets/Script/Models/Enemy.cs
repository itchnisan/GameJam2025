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
            int i = 0;
            if (other.name == "AoeScythe") {
                Debug.Log("scythe");
                i = 1;
            }
            if (other.CompareTag("PlayerAttack"))
            {
                
                Debug.Log(other.name);
                PlayerCharacter player = other.GetComponent<PlayerCharacter>();
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                //Debug.Log(rb.linearVelocity);
                if(rb == null) {
                    Debug.Log("rb null");
                    TakeDamage(player.attacks[i]);
                    
                }
                
                if(player == null) {
                    Debug.Log("player null");
                }

                else {
                //Debug.Log(rb.linearVelocity);
                TakeDamage(player.attacks[i],rb.linearVelocity);
                }
                
                
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            if (collision.collider.CompareTag("Player"))
            {
                StartCoroutine(base.KnockbackStun(rb,Vector2.zero));
            }
        }
    }
}
