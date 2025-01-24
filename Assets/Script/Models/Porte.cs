using UnityEngine;

public class Porte : MonoBehaviour
{
    private bool isPlayerNearby = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("joueur dans porte");
            isPlayerNearby = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            Debug.Log("joueur sort porte");
            isPlayerNearby = false;
        }
    }
}
