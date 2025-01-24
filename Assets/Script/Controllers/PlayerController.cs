using Models;
using UnityEngine;

public class PlayerController : PlayerCharacter
{
    private bool isMoving = false;

    private bool canShoot = true;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovementInput();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoAttack();

            Debug.Log("OK");
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Move();
        }
    }

    void HandleMovementInput()
    {
        if (stun)
        {
            isMoving = false;
            targetPosition = transform.position;
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


    }

    private void Move()
    {
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? run : walkSpeed;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = transform.position;
            isMoving = false;
        }
    }

    void DoAttack()
    {
        if (canShoot)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 shootDirection = mousePosition - transform.position;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //Debug.Log(shootDirection.normalized * 10f);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = shootDirection.normalized * 10f; // Assurez-vous que bulletPrefab a un Rigidbody2D attaché

            /*canShoot = false;
            Invoke(nameof(ResetShoot), 5); // Assurez-vous que shootCooldown est défini*/
        }
    }

    void ResetShoot()
    {
        canShoot = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bitch");
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }
}
