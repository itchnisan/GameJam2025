using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player; // Le Transform du joueur à suivre
    public float smoothSpeed = 0.125f; // Vitesse de lissage du déplacement de la caméra
    public Vector3 offset; // Décalage entre la caméra et le joueur

    void LateUpdate()
    {
        if (player != null)
        {
            // Position souhaitée de la caméra (avec décalage)
            Vector3 desiredPosition = player.position + offset;

            // Lissage pour un mouvement fluide
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Applique la position à la caméra
            transform.position = smoothedPosition;
        }
    }
}
