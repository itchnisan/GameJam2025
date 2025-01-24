using System.Collections;
using Assets.Script.Models;
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
        public float knockbackTime;
        public float invincibilitySecondes;

        public Vector2 targetPosition;


        [Header("States")]
        public bool stun = false;
        public bool inFire = false;
        public bool test = true;
        public bool canBeAttacked = true;

        [Header("References")]

        public GameObject bulletPrefab;

        public void TakeDamage(Attack attack)
        {
            if(canBeAttacked){
                health -= attack.damage;

                if (health <= 0)
                {
                    Die();
                }

                StopAllCoroutines(); //attention peut etre dangereux
                Rigidbody2D rb = GetComponent<Rigidbody2D>();

                Stun(rb);

                Vector2 knockbackTarget;

                if (attack.velocity.magnitude > 0.01f)
                {
                    knockbackTarget = attack.velocity;
                }
                else
                {
                    knockbackTarget = rb.linearVelocity * -1;
                }

                rb.AddForce(knockbackTarget * attack.knockback, ForceMode2D.Impulse);
            }
        }

        public void Stun(Rigidbody2D rb)
        {
            rb.linearVelocity = Vector2.zero;
            StartCoroutine(KnockbackStun());
            StartCoroutine(InvincibilityFrames(invincibilitySecondes));
        }

        public IEnumerator KnockbackStun()
        {
            stun = true;
            yield return new WaitForSeconds(knockbackTime);
            stun = false;
        }

        public IEnumerator InvincibilityFrames(float invincibilityTime)
        {
            canBeAttacked = false;

            //A CHANGER AVEC UN VRAI TRUC
            SpriteRenderer sp = GetComponent<SpriteRenderer>();

            Color oldColor = sp.color;
            sp.color = Color.yellow;
            //

            yield return new WaitForSeconds(invincibilityTime);
            canBeAttacked = true;

            //FIN
            sp.color = oldColor;

        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}