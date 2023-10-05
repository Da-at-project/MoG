using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementFind : MonoBehaviour
{
    private SmallBalahMovement smallBalah;

    Vector3 targetPos;

    void Start()
    {
        smallBalah = FindObjectOfType<SmallBalahMovement>();
    }

    private void Update()
    {
        if (targetPos != null)
        {
            targetPos.Set(smallBalah.transform.position.x, smallBalah.transform.position.y, this.transform.position.z);

            this.transform.position = targetPos;
            // this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}
