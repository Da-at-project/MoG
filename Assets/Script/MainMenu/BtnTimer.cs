using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTimer : MonoBehaviour
{
    public Transform transform;

    float maxTime = 20f;
    float time;
    private void Start()
    {
        transform = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= maxTime)
        {
            base.transform.SetAsLastSibling();
        }
    }
}
