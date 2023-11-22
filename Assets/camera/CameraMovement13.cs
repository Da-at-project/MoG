using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement13 : MonoBehaviour
{
    public GameObject target;
    // public float moveSpeed;
    Vector3 targetPos;

    float timer = 65.6f;

    private void Update()
    {
        if (targetPos != null && timer <= 0)
        {
            targetPos.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            this.transform.position = targetPos;
            return;
        }
        timer -= Time.deltaTime;
    }
}
