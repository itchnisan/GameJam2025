using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform[] spawnPoints; // Liste des spawn points définis dans l'ordre de transition
    private int currentRoomIndex = 0; // Index de la map actuelle dans la séquence

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Si on a encore des salles dans la séquence
            if (currentRoomIndex < spawnPoints.Length)
            {
                // Déplace le joueur au prochain spawn point
                other.transform.position = spawnPoints[currentRoomIndex].position;

                // Passe à la salle suivante
                currentRoomIndex++;
            }
            else
            {
                Debug.Log("Fin de la navigation !");
            }
        }
    }
}
