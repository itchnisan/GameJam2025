using System;
using System.Collections;
using Models;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Script.Models
{
    [CreateAssetMenu(fileName = "NewAttackTP", menuName = "Attack/NewAttackTP")]
    public class AttackTP : Attack
    {

        public AttackTP()
        {
            damage = 5;
            knockback = 0.75f;
            attackRange = 5;
            attackDuration = 0;
            attackDurationMax = 0;
            attackCooldownMax = 5;
            attackCooldown = 0;
            unlock = true;
        }

        public override void DoAttack(PlayerCharacter player)
        {
            {
        if (canAttack(player))
            {
                player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
                Debug.Log("tp");
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; // Ensure the z-coordinate is zero since we're working in 2D

                float distance = Vector3.Distance(player.transform.position, mousePosition);
                if (distance > attackRange)
                {
                    Debug.Log("Target is out of range");
                    mousePosition = mousePosition.normalized;
                    mousePosition *= attackRange;
                }
                player.transform.position = mousePosition;

                // Lancer le cooldown de l'attaque
                player.StartCoroutine(player.cd(this));
            }

            }

        }

        
    }
}