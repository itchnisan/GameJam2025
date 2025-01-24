using Models;
using UnityEngine;

namespace Assets.Script.Models
{
    public class Enemy:Entity
    {
        

        private void Start()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("PlayerAttack"))
            {
                TakeDamage(other.GetComponentsInParent<Attack>()[0].damage);
                
            }
        }
    }
}
