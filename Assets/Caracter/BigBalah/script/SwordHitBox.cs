using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{
    public float swordDamage = 30f;
    public float knockbackForce = 500f;
    public float thrust;
    public float knockTime;

    Collider2D swordCollider;
    public GameObject effect;
    public Vector3 faceRight = new Vector3(1.5f, 0f, 0f);
    public Vector3 faceLeft = new Vector3(-5f, 0f, 0f);
    public Vector3 faceUp = new Vector3(0f, 0f, 0f);
    public Vector3 faceDown = new Vector3(-1.5f, 0f, 0f);

    public float shakeTime = 0.1f;
    public float shakeIntensity = 5f;

    private Transform cam;

    private void Start()
    {
        if (swordCollider == null)
           swordCollider = GetComponent<Collider2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable == null) return;
        if(other.name == "MutantRat")
        {
            damagable.OnHit(swordDamage);
            Debug.Log("mutant rat");
        }
        Vector3 parentPos = gameObject.GetComponentInParent<Transform>().position;
        Vector2 dir = (Vector2)(other.gameObject.transform.position - parentPos).normalized;
        Vector2 knockback = dir * knockbackForce;
        damagable.OnHit(swordDamage, knockback);
        Debug.Log("rat");
    }

    void IsFacing(float dir)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (dir == 1)
        {
            gameObject.transform.localPosition = faceRight;
            swordCollider.offset = faceRight;
            swordCollider.transform.localEulerAngles = new Vector3(0, 0, 0);
            effect.transform.localPosition = new Vector3(3f, -0.5f, 0f);
            effect.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            sr.flipX = true;
        } 
        if (dir == 2)
        {
            gameObject.transform.localPosition = faceLeft;
            swordCollider.offset = faceLeft;
            swordCollider.transform.localEulerAngles = new Vector3(0, 0, 0);
            effect.transform.localPosition = new Vector3(-3f, -0.5f, 0f);
            effect.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            sr.flipX = false;
        }
        if (dir == 3)
        {
            gameObject.transform.localPosition = faceUp;
            swordCollider.offset = faceUp;
            swordCollider.transform.localEulerAngles = new Vector3(0, 0, 90);
            effect.transform.localPosition = new Vector3(3f, -1.5f, 0f);
            effect.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
        }
        if (dir == 4)
        {
            gameObject.transform.localPosition = faceDown;
            swordCollider.offset = faceDown;
            swordCollider.transform.localEulerAngles = new Vector3(0, 0, 90);
            effect.transform.localPosition = new Vector3(3f, -1.5f, 0f);
            effect.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
        }
        //Debug.Log(gameObject.transform.position);
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            Debug.Log("knock");
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }
    public void OnShakeCamera(float shakeTime = 1f, float shakeIntensity=0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        //StopCoroutine(ShakeByPosition());
        //S/tartCoroutine(ShakeByPosition());
    }
}
