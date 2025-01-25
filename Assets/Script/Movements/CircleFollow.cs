using Assets.Script.Models;
using Models;
using UnityEngine;

public class CircleFollow : MonoBehaviour
{
    public GameObject circle;  // Référence au cercle (sphere)
    private Vector3 offset;    // Décalage du cercle par rapport au centre de la capsule
    private Rigidbody2D rb;

    public AttackScythe Attack;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Attack = new AttackScythe();
    }
    

    void Start()
    {
        // Calculer l'offset initial entre le centre de la capsule et le cercle
        rb = circle.GetComponent<Rigidbody2D>();
        circle.transform.localScale = new Vector3(Attack.attackRange, Attack.attackRange, 1);
        offset = circle.transform.position - transform.position;

    }

    void Update()
    {
        // Mettre à jour la position du cercle pour qu'il suive le centre de la capsule
        rb.MovePosition(transform.position + offset);
    }
}