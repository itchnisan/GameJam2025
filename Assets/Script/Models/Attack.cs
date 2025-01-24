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
            damage = 10;
            knockback = 1; 
            attackRange = 1;
            attackDuration = 1;
            attackDurationMax = 1;
            attackCooldownMax = 1;
            attackCooldown = 0;
            unlock = true;
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {

        }

        public bool canAttack() {
            if (attackCooldown == 0 && unlock)
            {
                attackCooldown = attackCooldownMax;
                return true;
            }
            return false;
        }
    }
}
