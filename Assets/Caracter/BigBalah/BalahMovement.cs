using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahMovement : MonoBehaviour
{
    public Vector2 inputVec;
    public float defaultSpeed;
    float speed;

    Rigidbody2D rb;
    Animator anim;

    CircleCollider2D circleCol;
    public LayerMask layerMask;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);


        //디버그용 대시
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (BalahData.instance.nowSP > 100)
            {
                BalahData.instance.nowSP -= 100;
                Debug.Log("대시함");
            }
        }


        if (Vector2.zero == nextVec) {
            anim.SetBool("move", false);
        } 
        else {
            anim.SetBool("move", true);

            anim.SetFloat("h", inputVec.x);
            anim.SetFloat("v", inputVec.y);
        }

        if (Input.GetAxisRaw("Run") != 0f) {
            anim.SetBool("run", true);
            speed = defaultSpeed * 2f;
        } 
        else {
            anim.SetBool("run", false);
            speed = defaultSpeed;
        }

        rb.velocity = inputVec * speed;
    }
}
