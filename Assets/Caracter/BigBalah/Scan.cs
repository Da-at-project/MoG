using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan : MonoBehaviour
{
    public float scanDistance = 5f; // 스캔 거리

    void Update()
    {
        if (Input.GetButtonDown("Scan"))
        {
            PerformScan();
        }
    }

    void PerformScan()
    {
        // 플레이어가 보고 있는 방향으로 레이를 쏩니다.
        Vector2 scanDirection = transform.up; // 플레이어의 현재 보고 있는 방향 (위쪽)

        RaycastHit2D hit = Physics2D.Raycast(transform.position, scanDirection, scanDistance);

        if (hit.collider != null)
        {
            // 감지된 오브젝트의 태그를 확인하여 필터링합니다.
            if (hit.collider.CompareTag("object"))
            {
                Debug.Log("Detected Object: " + hit.collider.gameObject.name);
                // 여기에서 감지된 오브젝트에 대한 추가 동작을 수행할 수 있습니다.
            }
        }
    }
}
