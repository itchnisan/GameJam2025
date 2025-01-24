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
            Debug.Log("quoicoube1");
            if (other.CompareTag("PlayerAttack"))
            {
                Debug.Log("quoicoube2");
                Debug.Log(attackBall.damage);
                TakeDamage(attackBall.damage);
                
            }
        }
    }
}
