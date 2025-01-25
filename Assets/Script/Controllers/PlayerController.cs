using Models;
using UnityEngine;

public class PlayerController : PlayerCharacter
{
    private bool isMoving = false;

    //private bool canShoot = true;

    [SerializeField] // Rendre visible dans l'Inspector
    public static bool hasMelody1 = false; // Utilisé pour l'inspector
    public bool HasMelody1 
    { 
        get => hasMelody1; 
        private set => hasMelody1 = value; 
    }

    [SerializeField] // Rendre visible dans l'Inspector
    public static bool hasMelody2 = false; // Utilisé pour l'inspector
    public bool HasMelody2 
    { 
        get => hasMelody2; 
        private set => hasMelody2 = value; 
    }
    public GameObject bulletPrefab;
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

    public void CollectMelody(int melodyNumber)
    {
        switch (melodyNumber)
        {
            case 1:
                HasMelody1 = true;
                Debug.Log("Melody 1 récupérée !");
                break;
            case 2:
                HasMelody2 = true;
                Debug.Log("Melody 2 récupérée !");
                break;
            default:
                Debug.LogWarning("Numéro de mélodie non reconnu !");
                break;
        }
    }
    void DoAttackBall()
    {
        attackBall.DoAttack(this, bulletPrefab);
    }

    


    private void MakeMove(Vector2 _movement, float moveSpeed)
    {
        _movement.Normalize();
        _movement = moveSpeed * Time.deltaTime * _movement;

        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, _movement, ref reference, 0.05f);
    }

    void doAttack()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Vector2 clickPosition = new Vector2(mousePosition.x, mousePosition.y);

        //     if (canShoot) 
        //     {
        //         GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        //         bullet.GetComponent<Bullet>().Setup(shootDirection, 300f);
        //         Invoke("ResetShot", 0.5f);
        //         shootDirection = clickPosition;
        //     }
        // }
        }
    }

