using PixelCrushers.DialogueSystem.Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MutantRatController : MonoBehaviour, IDamagable
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;
    BoxCollider2D bc;

    public float HP;
    public float Damage;

    public float speed;
    public float rec;
    public float acc;
    Vector3 pos;

    bool isDelay;
    bool onMove;

    float timer = 3f;

    enum State
    {
        IDEL,
        CHASE,
        ATTACK,
        DASH
    }
    State state;

    public float Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    void Awake()
    {
        sr   = GetComponent<SpriteRenderer>();
        rb   = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        bc   = GetComponentInChildren<BoxCollider2D>();
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
        Debug.Log("Idel");
        Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= rec)
        {
            state = State.CHASE;
            anim.Play("MutantRatWalk");
        }
    }

    private void Chase()
    {
        Debug.Log("Chase");
        if (timer > 5f)
        {
            timer = 0f;
            state = State.DASH;
            return;
        }
        timer += Time.deltaTime;

        Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
        Vector3 dir = player.position - transform.position;

        anim.SetFloat("h", dir.x);
        anim.SetFloat("v", dir.y);

        if (dir.x > 0) sr.flipX = true;
        if (dir.x < 0) sr.flipX = false;

        Vector3 moveDirection = dir.normalized;
        Vector2 nextVec = moveDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);

        float dis = Vector3.Distance(player.position, transform.position);
        if (dis <= acc && timer >= 1f)
        {
            timer = 0f;
            state = State.ATTACK;
        }
    }

    private void Attack()
    {
        if (timer == 0f)
        {
            anim.Play("MutantRatAttack");

            Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
            Vector3 dir = player.position - transform.position;
            if (dir.x > 0)
            {
                sr.flipX = true;
                //bc.offset = 1.8f;
            }
            if (dir.x < 0) sr.flipX = false;

            Debug.Log("Attack");
        }
        if (timer >= 0.5f)
        {
            timer = 0f;
            state = State.CHASE;
            return;
        }

        timer += Time.deltaTime;
    }

    private void Dash()
    {
        Debug.Log("Dash");
        if (timer == 0f)
        {
            state = State.CHASE;
            return;
            anim.Play("MutantRatAttack");
        }
        if (timer >= 3f)
        {
            timer = 0f;
            state = State.CHASE;
            return;
        }



        timer += Time.deltaTime;
    }

    private void die()
    {

    }

    public void OnHit(float damage)
    {
        HP -= damage;
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        throw new NotImplementedException();
    }
}
