using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatHp : MonoBehaviour, IDamagable
{
    public Slider mySlider;
    public Vector3 barPos;
    public float maxHp;
    Rigidbody2D rb;

    public float force = 30f;

    public float Health
    {
        set
        {
            curHp = value;

            if(curHp <= 0 )
            {
                Destroy(gameObject);
            }
        }
        get
        {
            return curHp;
        }
    }
    public float curHp = 100;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        curHp = maxHp;
    }

    private void LateUpdate()
    {
        mySlider.value = curHp / maxHp;
    }
    private void FixedUpdate()
    {
        mySlider.transform.position 
            = Camera.main.WorldToScreenPoint(transform.position + barPos);
    }
    
    void IDamagable.OnHit(float damage)
    {
        curHp -= damage;
        Debug.Log("damage : " + damage + ", hp : " + curHp);
        if (curHp < 0)
            Destroy(gameObject);
    }

    void IDamagable.OnHit(float damage, Vector2 knockback)
    {
        curHp -= damage;
        rb.AddForce(knockback*force);
        Debug.Log("knockback" + knockback + ", hp : " + curHp);
        if(curHp < 0)
            Destroy(gameObject);
    }
}
