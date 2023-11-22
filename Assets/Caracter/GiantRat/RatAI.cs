using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatAI : MonoBehaviour, IDamagable
{
    public Slider mySlider;
    public Vector3 barPos;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;

    public GameObject target;
    public float speed;

    public float Health
    {
        set
        {
            curHP = value;

            if (curHP <= 0)
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return curHP;
        }
    }
    public float curHP = 100f;
    public float maxHP = 100f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dis = Vector3.Distance(target.transform.position, transform.position);
        if (dis > 15f)
        {
            anim.SetBool("move", false);
            return;
        }

        anim.SetBool("move", true);
        Vector3 dir = (target.transform.position - transform.position).normalized;
        if (dir.x > 0) sr.flipX = true;
        if (dir.x < 0) sr.flipX = false;
        //Debug.Log(dir * speed * Time.fixedDeltaTime);

        rb.AddForce(dir * speed * Time.fixedDeltaTime);
    }

    public void OnHit(float damage)
    {
        curHP -= damage;
        Debug.Log("damage : " + damage + ", hp : " + curHP);
        if (curHP < 0)
            Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        float force = 1f;
        curHP -= damage;
        rb.AddForce(knockback * force);
        Debug.Log("knockback" + knockback + ", hp : " + curHP);
        if (curHP < 0)
            Destroy(gameObject);
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

    private void LateUpdate()
    {
        mySlider.value = curHP / maxHP;
    }
    private void FixedUpdate()
    {
        mySlider.transform.position
            = Camera.main.WorldToScreenPoint(transform.position + barPos);
    }
}
