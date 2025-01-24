using Assets.Script.Models;
using UnityEngine;

namespace Models
{
    public class PlayerCharacter : Entity
    {
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

        private void EnemyDamage(Attack attack)
        {
            TakeDamage(attack.damage);

            //TODO période d'invincibilité
        }
    }
}