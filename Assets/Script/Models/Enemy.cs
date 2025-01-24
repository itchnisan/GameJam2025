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
            Debug.Log("collision touchée");
            //Collider2D collider = collision.collider;
            if (collider.CompareTag("PlayerAttack"))
            {
                TakeDamage(collider.GetComponentsInParent<Attack>()[0].damage);
                Debug.Log("degats");
            }
        }
    }
}
