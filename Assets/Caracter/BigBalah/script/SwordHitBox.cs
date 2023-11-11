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
    public Vector3 faceRight = new Vector3(1.5f, 0f, 0f);
    public Vector3 faceLeft = new Vector3(-1.5f, 0f, 0f);
    public Vector3 faceUp = new Vector3(0f, 0f, 0f);
    public Vector3 faceFoen = new Vector3(-1.5f, 0f, 0f);

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
        /*
        if (other.gameObject.CompareTag("enemy"))
        {
            GiantRatAI enemy = other.gameObject.GetComponent<GiantRatAI>();
            if (enemy == null) return;

            Rigidbody2D balah = GetComponentInParent<Rigidbody2D>();
            if (enemy == null) return;

        
            
            //StartCoroutine(Shake());

            enemy.rb.isKinematic = false;
            Vector2 difference = enemy.transform.position - balah.transform.position;
            difference = difference.normalized * thrust;
            Debug.Log(difference);
            enemy.rb.isKinematic = true;
            StartCoroutine(KnockCo(enemy.rb));

            //Debug.Log("enemy : " + enemy.transform.position);
            //Debug.Log("balah : " + balah.transform.position);
        }
        Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
        if(enemy == null) return;

        Rigidbody2D balah = other.GetComponentInParent<Rigidbody2D>();
        if (enemy == null) return;

        enemy.isKinematic = false;
        Vector2 difference = enemy.transform.position - balah.transform.position;
        Debug.Log("enemy : " + enemy.transform.position);
        Debug.Log("balah : " + balah.transform.position);
        difference = difference.normalized * thrust;
        Debug.Log(difference);
        enemy.isKinematic = true;
        StartCoroutine(KnockCo(enemy));
        */

        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable == null) return;

        Vector3 parentPos = gameObject.GetComponentInParent<Transform>().position;
        Vector2 dir = (Vector2)(parentPos - other.gameObject.transform.position).normalized;
        Vector2 knockback = dir * knockbackForce;
        Debug.Log("hit : " + other);
        
        damagable.OnHit(swordDamage, knockback);

    }

    void IsFacingRight(bool isFacingRight)
    {
        //Debug.Log(isFacingRight);
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
        /*

    private IEnumerator Shake()
    {
        Debug.Log("shake");
        Vector3 origin = cam.localPosition;
        float elapsedTime = 0f;

        while (elapsedTime < shakeTime)
        {
            Vector3 random = origin + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, random, Time.deltaTime * shakeSpeed);

            yield return null;

            elapsedTime += Time.deltaTime;
        }

        cam.localPosition = origin;
    }

        */
    public void OnShakeCamera(float shakeTime = 1f, float shakeIntensity=0.1f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        //StopCoroutine(ShakeByPosition());
        //S/tartCoroutine(ShakeByPosition());
    }
}
