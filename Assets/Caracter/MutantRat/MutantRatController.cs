using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MutantRatController : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;

    Vector2 moveDirection;
    Vector2 lastDirection;

    public float HP;
    public float Damage;

    public float speed;
    public float rec;
    public float acc;
    Vector3 pos;

    bool isDelay;
    bool onMove;

    enum State
    {
        IDEL = 1,
        CHASE,
        ATTACK,
        DASH
    }
    State state;

    void Awake()
    {
        sr   = GetComponent<SpriteRenderer>();
        rb   = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        state = State.IDEL;
    }

    void Update()
    {
        if (State.IDEL   == state) Idel();
        if (State.CHASE  == state) Chase();
        if (State.ATTACK == state) Attack();
        if (State.DASH   == state) Dash();
    }

    private void Idel()
    {
        Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance >= rec)
        {
            state = State.CHASE;
        }
    }

    private void Chase()
    {
        
    }

    private void Attack()
    {
    
    }

    private void Dash()
    {
        
    }
}
