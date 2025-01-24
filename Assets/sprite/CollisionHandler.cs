using Models;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private GameObject collidedObject;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {

            Debug.Log("Collided with: " + collision.gameObject.name);


            collidedObject = collision.gameObject;


            if (collidedObject != null)
            {

                Entity entity = collidedObject.GetComponent<Entity>();
                if (entity != null)
                {

                    entity.TakeDamage(10);
                }
            }
        }
    }
}
