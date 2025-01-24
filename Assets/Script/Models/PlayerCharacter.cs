using System.Collections;
using Assets.Script.Models;
using UnityEngine;

namespace Models
{
    public class PlayerCharacter : Entity
    {
        public bool canShoot = true;

        public bool isCoroutineRunning = false;

         [Header("Bullet")]
        public GameObject bulletPrefab;


        /*[Header("References")]
        public GameObject bulletPrefab;*/

        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("ca marche");
            Collider2D collider = collision.collider;

            if (collider.CompareTag("Enemy"))
            {
                //Attack attackComponent = collider.GetComponentsInParent<damage>();

                //EnemyDamage(attackComponent);
            }
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

        private void EnemyDamage(Attack attack)
        {
            TakeDamage(attack.damage);

            //TODO période d'invincibilité
        }
    }
}