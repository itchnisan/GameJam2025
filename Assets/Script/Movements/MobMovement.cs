using System;
using Assets.Script.Models;
using Models;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private Func<Rigidbody2D, Transform, float, MobAI> fn;
    public MobAI currentAI;
    private Enemy mobEntity;
    private Rigidbody2D mobRb;

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
    public MobAI baseStart()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mobEntity = GetComponent<Enemy>();
        mobRb = GetComponent<Rigidbody2D>();
        initAI();

        //FINAL
        return currentAI;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!mobEntity.stun)
        {
            currentAI.onNextTick();
        }
        else
        {
            //stun
            //mobRb.linearVelocity = Vector2.zero;
        }

    }
}
