using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalamanderAI : MonoBehaviour
{
    public float speed;
    public float RECOG_DISTANCE;
    public float ACCESS_DISTANCE;
    Vector3 pos;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Transform player;

    bool isDelay;
    bool onMove;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        player = GameObject.Find("Balah").GetComponent<BalahMovement>().transform;
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance >= RECOG_DISTANCE || isDelay)
            return;

        if (!onMove)
        {
            if (distance <= ACCESS_DISTANCE)
            { 
                //Debug.Log("Attack");
                Vector3 dir = (player.position - transform.position).normalized;
                if (dir.x > 0)
                    sr.flipX = false;
                if (dir.x < 0)
                    sr.flipX = true;

                anim.SetBool("attack", true);
                StartCoroutine(Attack());
            }
            else
            {
                // Debug.Log("Calc");
                onMove = true;
                anim.SetBool("move", true);
                CalcCoor();
            }
        }
        else
        {
            // Debug.Log("Move");
            Vector3 dir = (pos - transform.position).normalized;
            Vector2 nextVec = dir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + nextVec);

            if (nextVec.x > 0)
                sr.flipX = true;
            if (nextVec.x < 0)
                sr.flipX = false;

            Vector3 dir2 = (player.position - transform.position).normalized;
            float angle1 = Mathf.Atan2(dir.y, dir.x) + .5f;
            float angle2 = Mathf.Atan2(dir2.y, dir2.x) + .5f;
            if (Mathf.Abs(angle1 - angle2) >= 1.3f)
            {
                onMove = false;
                anim.SetBool("move", false);
                //Debug.Log("Re Calc");
            }

            float Pdistance = Vector3.Distance(pos, transform.position);
            if (Pdistance <= 0.1f || distance <= ACCESS_DISTANCE - 1f)
            {
                onMove = false;
                anim.SetBool("move", false);
                //Debug.Log("arrive to goal");
            }
        }

    }

    void CalcCoor()
    {
        // 1. 백터 값 계산
        Vector3 dir = (player.position - transform.position).normalized;

        // 2. 각도 계산
        float angle = Mathf.Atan2(dir.y, dir.x) + 1f;
        angle *= Mathf.PI;
        //Debug.Log(angle);

        // 3. 랜덤 각도 생성
        float newAngle = Mathf.Deg2Rad * (Random.Range(0f, 40f) - 20f);
        angle += newAngle;

        // 4. x, y값 계산
        dir.x = Mathf.Cos(angle) * (ACCESS_DISTANCE - .5f);
        dir.y = Mathf.Sin(angle) * (ACCESS_DISTANCE - .5f);
        //Debug.Log(dir);

        // 5. 최종 이동좌표 계산
        pos = player.position + dir;
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("attack", false);
        isDelay = false;
    }
}