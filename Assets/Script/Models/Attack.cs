using Models;
using UnityEngine;

namespace Assets.Script.Models
{
    [System.Serializable]
    
    public class Attack : ScriptableObject    {
        public int damage;
        public float knockback;

        public float attackRange;

        public float attackDuration;
        public float attackDurationMax;

        public float attackCooldownMax;

        public float attackCooldown;
        public bool unlock;


        public Attack()
        {
            damage = 0;
            knockback = 0; 
            attackRange = 0;
            attackDuration = 0;
            attackDurationMax = 0;
            attackCooldownMax = 0;
            attackCooldown = 0;
            unlock = true;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {

        }

        public virtual void DoAttack(PlayerCharacter player)
        {
        }

        public virtual void DoAttack(PlayerCharacter player,GameObject bulletPrefab)
        {
        }

        public bool canAttack(PlayerCharacter player) {
            Debug.Log("attaque nom:" + this.name);
            if (attackCooldown == 0 && unlock && !player.stun)
            {
                attackCooldown = attackCooldownMax;
                return true;
            }
            return false;
    }
}
}
