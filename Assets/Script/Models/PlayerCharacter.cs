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
                Attack attackComponent = collider.GetComponentsInParent<Attack>()[0];

                EnemyDamage(attackComponent);
            }
        }

        public IEnumerator cd() {
            isCoroutineRunning = true;
            while(attackBall.attackCooldown > 0) {
                attackBall.attackCooldown--;
                Debug.Log("Countdown : " + attackBall.attackCooldown);
                yield return new WaitForSeconds(1);
                
            }
            isCoroutineRunning = false;
        }
        private void EnemyDamage(Attack attack)
        {
            TakeDamage(attack.damage);

            //TODO période d'invincibilité
        }
    }
}