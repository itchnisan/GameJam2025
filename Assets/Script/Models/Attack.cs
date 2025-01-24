using UnityEngine;

namespace Assets.Script.Models
{
    public class Attack : MonoBehaviour
    {
        public int damage;
        public float knockback;
        public Vector2 velocity;

        private void Start()
        {
            velocity = GetComponent<Rigidbody2D>().linearVelocity;
        }
    }
}
