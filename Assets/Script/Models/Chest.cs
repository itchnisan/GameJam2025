using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject itemInside;
    public Transform spawnPoint;
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
