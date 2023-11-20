using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahMovement : MonoBehaviour
{
    SpriteRenderer rend;
    Rigidbody2D rb;
    Animator anim;

    Vector2 moveDirection; // 방향을 나타내는 변수
    Vector2 lastDirection; // 마지막으로 바라본 방향

    public float nowHP;
    public float Damage;

    //public Transform pos;
    public Vector2 boxSize;

    public bool invinc = false;
    public bool attack = false;
    public bool canAttack = true;

    public Vector2 inputVec;
    public float defaultSpeed;
    public float speed;

    public GameObject swordHitBox;
    Collider2D swordCollider;

    private float waitTime;
    InvenSc invenSc;

    GameObject obj;
    public GameObject Scene;
    SceneController2 s;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        invenSc = GetComponent<InvenSc>();
        //swordCollider = swordHitBox.GetComponent<Collider2D>();

        anim.SetBool("move", false);
        anim.SetBool("run", false);
    }

    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            //Debug.Log(waitTime);
            rb.velocity = new Vector2(0, 0);
            return;
        }

        Move();
        Attack();
        ScanObject();
    }

    void Move()
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
        if (Input.GetButton("Run")) speed = defaultSpeed * 2f;
        else                        speed = defaultSpeed;
        if (moveDirection != Vector2.zero)
            lastDirection = moveDirection;
        
        anim.SetBool("run", Input.GetButton("Run"));

        moveDirection.x = Mathf.RoundToInt(inputVec.x);     // 정수로 고정(좌우)
        moveDirection.y = Mathf.RoundToInt(inputVec.y);     // 정수로 고정(상하)
        lastDirection.x = Mathf.RoundToInt(lastDirection.x); // 정수로 고정(좌우)
        lastDirection.y = Mathf.RoundToInt(lastDirection.y); // 정수로 고정(상하)

        rb.velocity = inputVec * speed;
    } 

    void Attack()
    {
        if (!canAttack) return;
        if (!Input.GetMouseButtonDown(0) || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(transform.position, boxSize, 0);
        foreach (Collider2D collider in collider2Ds)
        {
            if(collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().OnDamage(5);
            }
        }

        Vector2 mPosition = Input.mousePosition; //마우스 좌표 저장
        Vector2 oPosition = transform.position; //게임 오브젝트 좌표 저장

        Vector2 target = Camera.main.ScreenToWorldPoint(mPosition);

        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;

        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        anim.SetFloat("attackH", 0f);
        anim.SetFloat("attackV", 0f);

        if (degree < 45f && degree > -45f)
        {
            anim.SetFloat("attackH", 1f);
            gameObject.BroadcastMessage("IsFacingRight", true);
            rend.flipX = true;  
        }
        if (degree < -135f || degree > 135f)
        {
            anim.SetFloat("attackH", -1f);
            gameObject.BroadcastMessage("IsFacingRight", false);
        }
        anim.SetFloat("h", anim.GetFloat("attackH"));

        if (degree < 135f && degree > 45f)
        {
            anim.SetFloat("attackV", 1f);
        }
        if (degree < -45f && degree > -135f)
        {
            anim.SetFloat("attackV", -1f);
        }
        anim.SetFloat("v", anim.GetFloat("attackV"));

        anim.Play("Attack");
    }

    void ScanObject()
    {
        Debug.DrawRay(rb.position, moveDirection * 2f, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rb.position, moveDirection, 3f, LayerMask.GetMask("NPC"));

        if(rayHit.collider != null)
        {
            obj = rayHit.collider.gameObject;
            Debug.Log("Hit");
        }
        else 
            obj = null;

        if(obj != null && Input.GetKeyDown(KeyCode.F))
        {
            s = Scene.GetComponent<SceneController2>();
            s.startScene();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            invenSc.changeActive();
        }
    }

    public void Wait(float waitTime)
    {
        this.waitTime = waitTime;
        Debug.Log("Wait for " + waitTime);
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
}