
using System.Collections.Generic;
using UnityEngine;

public class enableMobs : MonoBehaviour
{
    private List<GameObject> enemyList;

    private void Awake()
    {
        enemyList = new List<GameObject>();
        GameObject.FindGameObjectsWithTag("Enemy", enemyList);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("touché");

              

            
            
            foreach(GameObject enemy in enemyList)
            {
                Debug.Log(enemy.name);

                enemy.SetActive(true); 
            }

            Destroy(gameObject);
        }
        
    }
}
