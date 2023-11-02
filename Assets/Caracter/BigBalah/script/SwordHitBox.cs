using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float swordDamage = 30f;
    public float knockbackForce = 500f;

    Collider2D swordCollider;
    public Vector3 faceRight = new Vector3(1.5f, 0f, 0f);
    public Vector3 faceLeft = new Vector3(-1.5f, 0f, 0f);

    private void Start()
    {
        if (swordCollider == null)
           swordCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamagable damagable = collision.GetComponent<IDamagable>();
        if(damagable == null) return;

        Vector3 parentPos = gameObject.GetComponentInParent<Transform>().position;
        Vector2 dir = (Vector2)(parentPos - collision.gameObject.transform.position).normalized;
        Vector2 knockback = dir * knockbackForce;
        Debug.Log("hit");
        
        damagable.OnHit(swordDamage, knockback);
    }

    void IsFacingRight(bool isFacingRight)
    {
        Debug.Log(isFacingRight);
        if(isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        } 
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
        //Debug.Log(gameObject.transform.position);
    }
}
