using UnityEngine;

public class CircleFollow : MonoBehaviour
{
    public GameObject circle;  // Référence au cercle (sphere)
    private Vector3 offset;    // Décalage du cercle par rapport au centre de la capsule

    private Rigidbody2D rb;

    void Start()
    {
        // Calculer l'offset initial entre le centre de la capsule et le cercle
        rb = circle.GetComponent<Rigidbody2D>();
        offset = circle.transform.position - transform.position;
    }

    void Update()
    {
        // Mettre à jour la position du cercle pour qu'il suive le centre de la capsule
        rb.MovePosition(transform.position + offset);
    }
}