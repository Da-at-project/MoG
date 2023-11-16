using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoxController : MonoBehaviour
{
    public Vector2 moveDirection;
    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        anim.SetFloat("h", moveDirection.x);
        anim.SetFloat("v", moveDirection.y);
    }
}
