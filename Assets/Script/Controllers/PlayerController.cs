using Assets.Script.Models;
using Models;
using UnityEngine;

public class PlayerController : PlayerCharacter
{
    private bool isMoving = false;

    private bool canShoot = true;

    private Rigidbody2D rb;

    private Vector3 reference = Vector3.zero;

    void Start()
    {
        targetPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
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

        float deltaX = targetPosition.x - this.transform.position.x;
        float deltaY = targetPosition.y - this.transform.position.y;

        Vector2 movement = new Vector2(deltaX, deltaY);
        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        MakeMove(movement, currentSpeed);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = transform.position;
            rb.linearVelocity = Vector2.zero;
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
        rb.linearVelocity = Vector2.zero;
    }


    private void MakeMove(Vector2 _movement, float moveSpeed)
    {
        _movement.Normalize();
        _movement = _movement * moveSpeed * Time.deltaTime;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, _movement, ref reference, 0.05f);
    }
}
