using UnityEngine;

public class mobMovement : MonoBehaviour
{
    public MobAI currentAI;

    public GameObject mob;
    public GameObject player;

    public float moveSpeed = 250f;
    
    public float MoveSpeed
    {
        get { return moveSpeed; }

        set
        {
            moveSpeed = value;
            currentAI.MoveSpeed = value;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentAI = new AIRun(mob.GetComponent<Rigidbody2D>(),player.GetComponent<Transform>(), moveSpeed); //TODO changer si besoin
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        currentAI.onNextTick();
    }
}
