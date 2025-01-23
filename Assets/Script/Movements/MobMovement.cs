using System;
using Models;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private Func<Rigidbody2D, Transform, float, MobAI> fn;
    public MobAI currentAI;

    private GameObject player;

    private float moveSpeed;
    
    public MobMovement(Func<Rigidbody2D, Transform, float, MobAI> fn)
    {
        this.fn = fn;
    }

    public void initAI()
    {
        moveSpeed = this.GetComponent<Entity>().walkSpeed;
        currentAI = fn.Invoke(this.GetComponent<Rigidbody2D>(), player.GetComponent<Transform>(), moveSpeed);
    }

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
    public void baseStart()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initAI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        currentAI.onNextTick();
    }
}
