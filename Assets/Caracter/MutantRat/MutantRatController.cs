using PixelCrushers.DialogueSystem.Demo;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MutantRatController : MonoBehaviour, IDamagable
{
    public Slider mySlider;
    public Vector3 barPos;
    public GameObject area;

    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;

    public float HP;
    public float maxHP;
    public float Damage;

    public float speed;
    public float dashSpeed;
    public float rec;
    public float acc;
    Vector3 targetDir;

    bool isDelay;
    bool onDash = false;

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
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        state = State.IDEL;
    }

    void Update()
    {
        if (State.IDEL == state) Idel();
        if (State.CHASE == state) Chase();
        if (State.ATTACK == state) Attack();
        if (State.DASH == state) Dash();
    }

    private void Idel()
    {
        Debug.Log("Idel");
        Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= rec)
        {
            state = State.CHASE;
            mySlider.gameObject.SetActive(true);
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
            area.SetActive(true);
            anim.Play("MutantRatAttack");

            Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
            Vector3 dir = player.position - transform.position;
            if (dir.x > 0)
                sr.flipX = true;
            if (dir.x < 0)
                sr.flipX = false;

            Debug.Log("Attack");
        }
        if (timer >= 0.5f)
        {
            timer = 0f;
            state = State.CHASE;
            area.SetActive(false);
            return;
        }

        timer += Time.deltaTime;
    }

    private void Dash()
    {
        //Debug.Log(timer);
        if (timer == 0f)
        {
            anim.Play("MutantRatCharge");

            Transform player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
            targetDir = (player.position - transform.position).normalized;
            if (targetDir.x > 0) sr.flipX = true;
            else sr.flipX = false;
        }
        if (timer >= 0.8f && !onDash)
        {
            anim.Play("MutantRatDash");
            onDash = true;
        }
        else if (timer >= 0.8f && onDash)
        {
            rb.AddForce(targetDir * dashSpeed * Time.fixedDeltaTime);
        }
        if (timer >= 1.8f)
        {
            onDash = false;
            timer = 0f;
            state = State.CHASE;
            anim.Play("MutantRatWalk");
            return;
        }

        timer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        IDamagable damagable = collision.collider.GetComponent<IDamagable>();
        if (damagable != null && collision.gameObject.name == "Balah")
        {
            damagable.OnHit(20f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if (damagable != null && collision.gameObject.name == "Balah")
        {
            damagable.OnHit(20f);
        }
    }

    private void die()
    {

    }

    public void OnHit(float damage)
    {
        HP -= damage;
        if (HP < 0)
            Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        throw new NotImplementedException();
    }

    private void LateUpdate()
    {
        mySlider.value = HP / maxHP;
    }
}
