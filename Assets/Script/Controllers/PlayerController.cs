using Assets.Script.Models;
using Models;
using UnityEngine;

public class PlayerController : PlayerCharacter
{
    private bool isMoving = false;

    //private bool canShoot = true;

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

        if (Input.GetKeyDown(KeyCode.Space) && !isCoroutineRunning)
        {
            DoAttackBall();
            Debug.Log("OK");
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q)) && !isCoroutineRunning)
        {
            Debug.Log("AAAAAAAAAAAA");
            DoAttackScythe();
        }

        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) && !isCoroutineRunning)
        {
            isMoving = false;
            Debug.Log("TPPPPPPP");
            DoTP();
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

    void DoAttackBall()
    {
        attacks[0].DoAttack(this, bulletPrefab);
    }

    void DoAttackScythe()
    {
        attacks[1].DoAttack(this);
    }

    void DoTP()
    {
        attacks[2].DoAttack(this);
    }

    


    private void MakeMove(Vector2 _movement, float moveSpeed)
    {
        _movement.Normalize();
        _movement = moveSpeed * Time.deltaTime * _movement;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, _movement, ref reference, 0.05f);
    }
}
