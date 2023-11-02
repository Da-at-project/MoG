using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatHp : MonoBehaviour, IDamagable
{
    public Slider mySlider;
    public float maxHp;
    Rigidbody2D rb;

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
    }

    private void LateUpdate()
    {
        mySlider.value = curHp / maxHp;
    }
    private void FixedUpdate()
    {
        mySlider.transform.position 
            = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1.5f, 0));
    }
    
    void IDamagable.OnHit(float damage)
    {
        curHp -= damage;
        Debug.Log("damage : " + damage);
        Debug.Log("hp : " + curHp);
        if (curHp < 0)
        {
            Destroy(gameObject);
        }
    }

    void IDamagable.OnHit(float damage, Vector2 knockback)
    {
        curHp -= damage;
        rb.AddForce(knockback);
        Debug.Log("knockback" + knockback);
        Debug.Log("hp : " + curHp);
        if(curHp < 0)
        {
            Destroy(gameObject);
        }
    }
}
