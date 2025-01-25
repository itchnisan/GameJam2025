using System.Collections;
using Assets.Script.Models;
using UnityEngine;
using Assets.Script.Models;
using UnityEngine.U2D.IK;

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

        public bool isCoroutineRunning = false;


        [Header("States")]
        public bool stun = false;
        public bool inFire = false;
        public bool test = true;
        public bool canBeAttacked = true;

        [Header("Attacks")]
        public Attack[] attacks;




        public void TakeDamage(Attack attack, Vector2? velocity = null)
        {
            if (canBeAttacked)
            {
                health -= attack.damage;

                if (health <= 0)
                {
                    Die();
                }

                //StopAllCoroutines(); //attention peut etre dangereux
                Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();

                Stun(rb);
            }
        }

        public void TakeDameContinue(Attack attack,Vector2? velocity = null) {
            Rigidbody2D rb = GetComponentInParent<Rigidbody2D>();
            Vector2 knockbackTarget;
            Debug.Log(velocity);
                if(velocity == null) {
                    Debug.Log("1");
                    velocity = Vector2.zero;
                }
                if (velocity.HasValue && velocity.Value.sqrMagnitude > 0.0001f)
                {
                    Debug.Log("2");
                    knockbackTarget = (Vector2)velocity;
                }
                else
                {
                    Debug.Log("3");
                    Debug.Log(rb.linearVelocity);
                    knockbackTarget = rb.linearVelocity * -1;
                }
                rb.AddForce(knockbackTarget * attack.knockback, ForceMode2D.Impulse);
        }

        public void Stun(Rigidbody2D rb)
        {
            
            StartCoroutine(KnockbackStun(rb));
            StartCoroutine(InvincibilityFrames(invincibilitySecondes));
        }

        public IEnumerator KnockbackStun(Rigidbody2D rb)
        {
            Vector2 oldVelocity = rb.linearVelocity;
            rb.linearVelocity = Vector2.zero;
            stun = true;
            yield return new WaitForSeconds(knockbackTime);
            stun = false;
            TakeDameContinue(attacks[0],oldVelocity);
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

                public IEnumerator cd(Attack attack) {
            isCoroutineRunning = true;
            while(attack.attackCooldown > 0) {
                attack.attackCooldown--;
                Debug.Log("Countdown : " + attack.attackCooldown);
                yield return new WaitForSeconds(1);
                
            }
            isCoroutineRunning = false;
        }

        public IEnumerator lifeTime(GameObject obj,Attack attack) {
            while(attack.attackDuration > 0) {
                attack.attackDuration--;
                Debug.Log("duration : " + attack.attackDuration);
                yield return new WaitForSeconds(1);
                
            }
            attack.attackDuration = attack.attackDurationMax;
            Destroy(obj);
        }

        public IEnumerator DestroyProjectileAfterRange(GameObject Projectile, Vector3 targetPosition)
        {
            while (Vector3.Distance(Projectile.transform.position, targetPosition) > 0.1f)
            {
            yield return null;
            }
            Destroy(Projectile);
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}