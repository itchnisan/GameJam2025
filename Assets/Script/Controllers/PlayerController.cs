using UnityEngine;
using Models;

public class PlayerController : PlayerCharacter
{
    private Vector2 targetPosition;

    private Vector2 shootDirection;
    private bool isMoving = false;

    private bool canShoot = true;

    public GameObject bulletPrefab;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();

        //test degat
        /*if (Time.time % 3 < Time.deltaTime)
            {
            TakeDamage(10); // Call TakeDamage every 3 seconds with a damage value of 10
            }
        Debug.Log("Health: " + health);*/
    }

    void HandleMovement()
    {
        if (stun)
        {
            isMoving = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition = new Vector2(mousePosition.x, mousePosition.y);

            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero); 
            if (hit.collider != null) 
            {
                targetPosition = clickPosition;
                isMoving = true;
            }
        }

        if (isMoving)
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    void doAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition = new Vector2(mousePosition.x, mousePosition.y);

            if (canShoot) 
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().Setup(shootDirection, 300f);
                Invoke("ResetShot", 0.5f);
                shootDirection = clickPosition;
            }
        }
    }
}
