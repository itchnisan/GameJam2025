using UnityEngine;
using Models;

public class PlayerController : PlayerCharacter
{
    private Vector2 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleMovement();
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
}
