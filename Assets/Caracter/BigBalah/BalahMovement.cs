using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahMovement : MonoBehaviour
{
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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //디버그용 대시
        if (Input.GetKeyDown("space"))
        {
            if (BalahData.instance.nowSP > dashSP)
            {
                BalahData.instance.nowSP -= dashSP;
                Debug.Log("대시함");
            }
        }
    }

    void FixedUpdate()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

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

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);

        if (Vector2.zero == nextVec) {
            anim.SetBool("move", false);
        } 
        else {
            anim.SetBool("move", true);

            anim.SetFloat("h", inputVec.x);
            anim.SetFloat("v", inputVec.y);
        }

        rb.velocity = inputVec;
    }
}
