using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementWater : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;

    Vector3 targetPos;

    public float timer = 30f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos != null && timer >= 0)
        {
            targetPos.Set(target1.transform.position.x, target1.transform.position.y, this.transform.position.z);

            this.transform.position = targetPos;
            // this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
            timer -= Time.deltaTime;
            return;
        }
        if (targetPos != null)
        {
            targetPos.Set(target2.transform.position.x, target2.transform.position.y, this.transform.position.z);

            this.transform.position = targetPos;
        }
    }
}
