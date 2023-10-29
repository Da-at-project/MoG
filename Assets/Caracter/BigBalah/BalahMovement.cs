using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahMovement : MonoBehaviour
{
    public SpriteRenderer rend;
    Rigidbody2D rb;
    Animator anim;

    Vector2 moveDirection; // 방향을 나타내는 변수
    Vector2 lastDirection; // 마지막으로 바라본 방향

    public float maxHP;
    public float nowHP;
    public float Damage;

    //public Transform pos;
    public Vector2 boxSize;

    public bool invinc = false;
    public bool attack = false;

    public Vector2 inputVec;
    public float defaultSpeed;
    float speed;

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

        // 입력 벡터를 정규화하여 방향 벡터 계산
        moveDirection = inputVec.normalized;
        attack = true;
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
            Debug.Log("히히");
            //Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
            /*foreach (Collider2D collider in collider2Ds)
            {
                if(collider.tag == "Enemy")
                {
                    collider.GetComponent<Enemy>().OnDamage(5);
                }
            }*/
            if (h > 0)
            {
                rend.flipX = true;
            }
            anim.Play("Attack");
        }

        if (moveDirection != Vector2.zero)
        {
            lastDirection = moveDirection;
        }
        Debug.DrawRay(transform.position, lastDirection, Color.red);

        moveDirection.x = Mathf.RoundToInt(inputVec.x);     // 정수로 고정(좌우)
        moveDirection.y = Mathf.RoundToInt(inputVec.y);     // 정수로 고정(상하)

        lastDirection.x = Mathf.RoundToInt(lastDirection.x); // 정수로 고정(좌우)
        lastDirection.y = Mathf.RoundToInt(lastDirection.y); // 정수로 고정(상하)

        rb.velocity = inputVec * speed;
    }

    void FixedUpdate()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            rend.flipX = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (collision.gameObject.tag == "Enemy" && invinc == false)
        {
            OnDamaged(enemy);
        }
    }

    void OnDamaged(GameObject enemy)
    {
        nowHP -= enemy.GetComponent<Enemy>().damage;
        if (nowHP <= 0)
            Dead();
        gameObject.layer = 11;
        rend.color = new Color(1, 1, 1, 0.6f);
        invinc = true;
        Invoke("OffDamaged", 0.6f);
    }

    void OffDamaged()
    {
        invinc = false;
        gameObject.layer = 10;
        rend.color = new Color(1, 1, 1, 1);
    }

    void Dead()
    {
        Debug.Log("die");
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
    */
}