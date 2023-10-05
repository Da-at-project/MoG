using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class SmallBalahMovement : MonoBehaviour
{
    static public SmallBalahMovement instance;

    public Vector2 inputVec;
    public float defaultSpeed;
    //float speed;

    Rigidbody2D rb;
    public Animator anim;

    public string currentMap;
    public string beforeMap;

    private float waitTime;
    public GameObject ui;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponentInChildren<Animator>();
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            //Debug.Log(waitTime);
            rb.velocity = new Vector2(0, 0);
            return;
        }

        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        Vector2 nextVec = inputVec.normalized * defaultSpeed * Time.fixedDeltaTime;
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

        if (inputVec.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (inputVec.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        rb.velocity = inputVec;
    }

    public void Wait(float waitTime)
    {
        this.waitTime = waitTime;
    }
}
