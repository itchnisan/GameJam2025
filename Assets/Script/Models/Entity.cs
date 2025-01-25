using System.Collections;
using Assets.Script.Models;
using UnityEngine;
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

        public bool isCoroutineARunning = false;
        public bool isCoroutineBRunning = false;
        public bool isCoroutineCRunning = false;


        [Header("States")]
        public bool stun = false;
        public bool inFire = false;
        public bool test = true;
        public bool canBeAttacked = true;

        [Header("Attacks")]
        public Attack[] attacks;

        void Start()
        {
            Debug.Log("attacks.Length: " + attacks.Length);
                for (int i = 0; i < attacks.Length; i++)
    {
        attacks[i] = Instantiate(attacks[i]);
        Debug.Log($"Attack {i} Instance ID: {attacks[i].GetInstanceID()}");
    }
        }




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
                    knockbackTarget = Vector2.one * -1;
                }
                Stun(rb,knockbackTarget * attack.knockback);
            }
        }

        public void Stun(Rigidbody2D rb,Vector2 vect)
        {
            
            StartCoroutine(KnockbackStun(rb,vect));
            StartCoroutine(InvincibilityFrames(invincibilitySecondes));
        }

        public IEnumerator KnockbackStun(Rigidbody2D rb,Vector2 vect)
        {
            rb.linearVelocity = vect;
            stun = true;
            yield return new WaitForSeconds(knockbackTime);
            stun = false;
            rb.linearVelocity = Vector2.zero;
            
        }

        public IEnumerator InvincibilityFrames(float invincibilityTime)
        {
            canBeAttacked = false;
            GetComponent<CircleCollider2D>().enabled = false;

            //A CHANGER AVEC UN VRAI TRUC
            SpriteRenderer sp = GetComponent<SpriteRenderer>();

            Color oldColor = sp.color;
            sp.color = Color.yellow;
            //

            yield return new WaitForSeconds(invincibilityTime);
            GetComponent<CircleCollider2D>().enabled = true;
            canBeAttacked = true;

            //FIN
            sp.color = oldColor;

        }

                public IEnumerator cdA(Attack attack) {
                    isCoroutineARunning = true;
            while(attack.attackCooldown > 0) {
                attack.attackCooldown--;
                Debug.Log("Countdown : " +attack.name + attack.attackCooldown);
                yield return new WaitForSeconds(1);
                
            }
            isCoroutineARunning = false;
        }
              public IEnumerator cdB(Attack attack) {
                isCoroutineBRunning = true;
            while(attack.attackCooldown > 0) {
                attack.attackCooldown--;
                Debug.Log("Countdown : " +attack.name + attack.attackCooldown);
                yield return new WaitForSeconds(1);
                
            }
            isCoroutineBRunning = false;
        }
              public IEnumerator cdC(Attack attack) {
                isCoroutineCRunning = true;
            while(attack.attackCooldown > 0) {
                attack.attackCooldown--;
                Debug.Log("Countdown : " +attack.name + attack.attackCooldown);
                yield return new WaitForSeconds(1);
                
            }
            isCoroutineCRunning = false;
        }

        public IEnumerator lifeTime(GameObject obj,Attack attack) {
                obj.GetComponent<PolygonCollider2D>().enabled = true;
                yield return new WaitForSeconds(attack.attackDuration);
                obj.GetComponent<PolygonCollider2D>().enabled = false;
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