using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject itemInside; 
    public Transform spawnPoint; 
    public int melodyNumber = 0;  

    public Animator animator;

    private bool isPlayerNearby = false;
    private bool isOpened = false;

    void Update()
    {

        if (isPlayerNearby && !isOpened && Input.GetKeyDown(KeyCode.E))
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        isOpened = true;


        if (animator != null)
        {
            animator.SetTrigger("Open");
        }


        if (itemInside != null && spawnPoint != null)
        {
            Instantiate(itemInside, spawnPoint.position, spawnPoint.rotation);
        }
        
        Debug.Log("Le coffre a été ouvert !");

        CollectMelodyForPlayer();

    }

    private void CollectMelodyForPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.CollectMelody(melodyNumber);
                Debug.Log($"Le joueur a récupéré la mélodie {melodyNumber} !");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Le joueur est entré dans la zone du coffre.");
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
