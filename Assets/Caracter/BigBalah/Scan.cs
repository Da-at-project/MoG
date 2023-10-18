using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float scanDistance = 5f; // ��ĵ �Ÿ�

    void Update()
    {
        if (Input.GetButtonDown("Scan"))
        {
            PerformScan();
        }
    }

    void PerformScan()
    {
        // �÷��̾ ���� �ִ� �������� ���̸� ���ϴ�.
        Vector2 scanDirection = transform.up; // �÷��̾��� ���� ���� �ִ� ���� (����)

        RaycastHit2D hit = Physics2D.Raycast(transform.position, scanDirection, scanDistance);

        if (hit.collider != null)
        {
            // ������ ������Ʈ�� �±׸� Ȯ���Ͽ� ���͸��մϴ�.
            if (hit.collider.CompareTag("object"))
            {
                Debug.Log("Detected Object: " + hit.collider.gameObject.name);
                // ���⿡�� ������ ������Ʈ�� ���� �߰� ������ ������ �� �ֽ��ϴ�.
            }
        }
    }
}
