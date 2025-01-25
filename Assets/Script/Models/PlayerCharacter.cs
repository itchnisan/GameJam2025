using System.Collections;
using Assets.Script.Models;
using UnityEngine;

namespace Models
{
    public class PlayerCharacter : Entity
    {
        //public bool canShoot = true;

        

         [Header("References")]
        public GameObject bulletPrefab;
        public GameObject scythePrefab;


        /*[Header("References")]
        public GameObject bulletPrefab;*/

        void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log("ca marche");
            Collider2D collider = collision.collider;

            if (collider.CompareTag("Enemy"))
            {
                Debug.Log("attaque prise");
                Enemy enemy = collider.GetComponentInParent<Enemy>();
                Rigidbody2D rb = collider.GetComponentInParent<Rigidbody2D>();
                Debug.Log(rb.linearVelocity);
                if(enemy == null) {
                    Debug.Log("enemy null");
                }
                if(rb == null) {
                    TakeDamage(enemy.attacks[0]);
                    Debug.Log("rbenemy null");
                }
                
                else {
                TakeDamage(enemy.attacks[0],rb.linearVelocity);
                }
            }
        }
    }
}