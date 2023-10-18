using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[AddComponentMenu("UI/TextMeshPro - Text (UI)", 11)]

public class BalahMovement : MonoBehaviour
{
    public SpriteRenderer rend;

    Vector2 moveDirection; // ������ ��Ÿ���� ����
    Vector2 lastDirection; // ���������� �ٶ� ����

    public float maxHP;
    public float nowHP;

    public Vector2 inputVec;
    public float defaultSpeed;
    float speed;

    public float dashSP = 30;

    Rigidbody2D rb;
    Animator anim;

    CircleCollider2D circleCol;
    public LayerMask layerMask;


    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        float h = anim.GetFloat("h");

        // �Է� ���͸� ����ȭ�Ͽ� ���� ���� ���
        moveDirection = inputVec.normalized;

        Vector2 nextVec = moveDirection * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);

        if (Vector2.zero == nextVec)
        {
            anim.SetBool("move", false);
        }
        else
        {
            anim.SetBool("move", true);

            anim.SetFloat("h", inputVec.x);
            anim.SetFloat("v", inputVec.y);
        }

        if (Input.GetAxisRaw("Run") != 0f)
        {
            anim.SetBool("run", true);
            speed = defaultSpeed * 2f;
        }
        else
        {
            anim.SetBool("run", false);
            speed = defaultSpeed;
        }


        if (Input.GetKeyDown(KeyCode.X) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (h > 0)
            {
                rend.flipX = true;
            }
            anim.SetTrigger("Attack");
        }

        if (moveDirection != Vector2.zero)
        {
            lastDirection = moveDirection;
        }
        Debug.DrawRay(transform.position, lastDirection, Color.red);

        moveDirection.x = Mathf.RoundToInt(inputVec.x);     // ������ ����(�¿�)
        moveDirection.y = Mathf.RoundToInt(inputVec.y);     // ������ ����(����)

        lastDirection.x = Mathf.RoundToInt(lastDirection.x); // ������ ����(�¿�)
        lastDirection.y = Mathf.RoundToInt(lastDirection.y); // ������ ����(����)

        rb.velocity = inputVec * speed;
    }

    void FixedUpdate()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            rend.flipX = false;
        }
    }

}