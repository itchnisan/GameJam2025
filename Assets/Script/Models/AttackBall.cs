using System.Collections;
using Models;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Script.Models
{
    [CreateAssetMenu(fileName = "NewAttackBall", menuName = "Attack/AttackBall")]
    public class AttackBall : Attack
    {

        public AttackBall()
        {
            damage = 10;
            knockback = 0.25f;
            attackRange = 10f;
            attackDuration = 0;
            attackDurationMax = 0;
            attackCooldownMax = 3;
            attackCooldown = 0;
            unlock = true;
        }
        public override void DoAttack(PlayerCharacter player, GameObject bulletPrefab)
        {
            if (canAttack(player))
            {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = mousePosition - player.transform.position;

            GameObject bullet = Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDirection.normalized * 10f; // vitesse de la bullet
            

            player.StartCoroutine(player.cdA(this));
            //player.StartCoroutine(player.lifeTime(bullet));

            Vector3 targetPosition = player.transform.position + (Vector3)(shootDirection.normalized * attackRange);
            player.StartCoroutine(player.DestroyProjectileAfterRange(bullet, targetPosition));
            }
        }


    }
}