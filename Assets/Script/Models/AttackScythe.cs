using System;
using System.Collections;
using Models;
using Unity.VisualScripting;
using UnityEngine;
namespace Assets.Script.Models
{
    [CreateAssetMenu(fileName = "NewAttackScythe", menuName = "Attack/AttackScythe")]
    public class AttackScythe : Attack
    {

        public AttackScythe()
        {
            damage = 5;
            knockback = 0.75f;
            attackRange = 3;
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
    Debug.Log("attaque");


    CircleFollow circle = player.GetComponentInParent<CircleFollow>();
    Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0; // S'assurer que la position Z correspond à votre plan 2D

        // Calculer la direction entre le cercle et la souris
        Vector3 direction = mouseWorldPosition - circle.transform.position;

        // Calculer l'angle de rotation en radians et le convertir en degrés
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Appliquer la rotation au cercle
        circle.circle.transform.rotation = Quaternion.Euler(0, 0, angle-180f);
    player.StartCoroutine(player.lifeTime(circle.circle,this));
    // Lancer le cooldown de l'attaque
    player.StartCoroutine(player.cdB(this));
}

}

        }

        
    }
}