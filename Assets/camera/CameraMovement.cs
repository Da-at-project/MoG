using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    // public float moveSpeed;
    Vector3 targetPos;

    private void Update()
    {
        if(targetPos != null)
        {
            targetPos.Set(target.transform.position.x, target.transform.position.y, -10f);

            this.transform.position = targetPos;
            // this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
