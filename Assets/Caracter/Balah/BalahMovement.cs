using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[AddComponentMenu("UI/TextMeshPro - Text (UI)", 11)]

public class BalahMovement : MonoBehaviour
{
    public TextMeshProUGUI tmpUgui;
    public GameObject Target;

    Vector2 moveDirection; // ������ ��Ÿ���� ����
    Vector2 lastDirection; // ���������� �ٶ� ����

    public float maxHP;
    public float nowHP;

    public Vector2 inputVec;
    public float defaultSpeed;
    float speed;

    Rigidbody2D rb;
    Animator anim;

    CircleCollider2D circleCol;
    public LayerMask layerMask;

    bool scanStarted = false; // ��ĵ�� ���۵Ǿ����� ����

    void Awake()
    {
        Target.SetActive(false);
        tmpUgui = Target.GetComponentInChildren<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // �Է� ���͸� ����ȭ�Ͽ� ���� ���� ���
        moveDirection = inputVec.normalized;

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

        if (Input.GetAxisRaw("Scan") != 0 && !scanStarted)
        {
            StartScanning();
            scanStarted = true;
        }

        if (Input.GetAxisRaw("Scan") == 0)
        {
            scanStarted = false;
        }

        if (moveDirection != Vector2.zero)
        {
            lastDirection = moveDirection;
        }
        Debug.DrawRay(transform.position, lastDirection, Color.red);

        moveDirection.x = Mathf.RoundToInt(inputVec.x);     // ������ ����(�¿�)
        moveDirection.y = Mathf.RoundToInt(inputVec.y);     // ������ ����(����)

        lastDirection.x = Mathf.RoundToInt(lastDirection.x); // ������ ����(�¿�)
        lastDirection.y = Mathf.RoundToInt(lastDirection.y); // ������ ����(����)

        rb.velocity = inputVec * speed;
    }

    void StartScanning()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, Mathf.Infinity);
        if (hit.collider != null && hit.collider.CompareTag("object"))
        {
            ObjectManager objectManager = hit.collider.GetComponent<ObjectManager>();

            if (objectManager != null)
            {
                // ObjectManager�� QuestID ���� �� ��������
                int questIDValue = objectManager.QuestID;

                switch (questIDValue)
                {
                    case 0:
                        Debug.Log("QuestID : " + questIDValue);
                        Target.SetActive(true);
                        break;
                    case 1:
                        Debug.Log("QuestID : " + questIDValue);
                        Target.SetActive(true);
                        break;
                }

                // �ؽ�Ʈ ����:
                if (tmpUgui != null)
                {
                    tmpUgui.text = "Quest ID: " + questIDValue; // �ؽ�Ʈ ����
                }
            }
        }
    }
}