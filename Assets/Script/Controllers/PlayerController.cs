using Models;
using UnityEngine;

public class PlayerController : PlayerCharacter
{
    private bool isMoving = false;

    
    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovementInput();

        if (Input.GetKeyDown(KeyCode.Space) && !isCoroutineRunning)
        {
            DoAttackBall();

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
            isMoving = false;
        }
    }

    void DoAttackBall()
    {
        attackBall.DoAttack(this, bulletPrefab);
    }
}
