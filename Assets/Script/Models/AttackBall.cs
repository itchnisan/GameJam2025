using System.Collections;
using Models;
using UnityEngine;
namespace Assets.Script.Models
{
    [CreateAssetMenu(fileName = "NewAttackBall", menuName = "Attack/AttackBall")]
    public class AttackBall : Attack
    {

        public AttackBall()
        {
            damage = 10;
            knockback = 0;
            attackRange = 10;
            attackDuration = 4;
            attackCooldownMax = 2;
            attackCooldown = 0;
            unlock = true;
        }
        public void DoAttack(PlayerCharacter player, GameObject bulletPrefab)
        {
            if (canAttack())
            {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = mousePosition - player.transform.position;

            GameObject bullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDirection.normalized * 10f; // Assurez-vous que bulletPrefab a un Rigidbody2D attaché

            player.StartCoroutine(player.cd());
            }
        }

        
    }
}