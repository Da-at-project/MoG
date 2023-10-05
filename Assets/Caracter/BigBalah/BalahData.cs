using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahData : MonoBehaviour
{
    private void Start()
    {
        nowHP = maxHP;
        nowSP = maxSP;
    }

    private void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        if (Time.time > _nextTime)
        {
            _nextTime = Time.time + _pointTime;

            
            if (nowSP < maxSP) //sp회복
                nowSP++;
            else
                nowSP = maxSP;

            if (nowSP < 0)
                nowSP = 0;

            if (nowHP > maxHP) //hp고정
                nowHP = maxHP;

        }

    }


    public static BalahData instance;

    [Header("# balah Info")]
    public float maxHP = 100;

    public float nowHP;

    public float maxSP = 1000;

    public float nowSP;

    [Header("# sp regen control")]
    private float _pointTime = 0.1f; // sp회복 딜레이 시간

    private float _nextTime = 0.0f; // 다음번 실행할 시간



}
