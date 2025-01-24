using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootToTarget : MonoBehaviour
{
    [Header("Objects")]
    public Transform targetTransform;
    public GameObject projectile;

    [Header("Cooldown")]
    public int maxCD;
    public int CD = 0;

    [Header("Misc")]
    public float projectileSpeed;

    private bool canShoot = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(targetTransform == null)
        {
            targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            Shoot();

            StartCoroutine(reduceCD());
        }
    }

    public IEnumerator reduceCD()
    {
        canShoot = false;

        while (CD < maxCD)
        {
            yield return new WaitForSeconds(1);
            CD++;
        }

        //fin du CD
        CD = 0;
        canShoot = true;
    }

    private void Shoot()
    {
        float deltaX = targetTransform.position.x - transform.position.x;
        float deltaY = targetTransform.position.y - transform.position.y;

        Vector2 targetedVect = new Vector2(deltaX, deltaY);
        targetedVect.Normalize();
        targetedVect = targetedVect * projectileSpeed;

        GameObject newProj = Instantiate(projectile, transform.position, Quaternion.identity);
        newProj.GetComponent<Rigidbody2D>().linearVelocity = targetedVect;
    }
}
