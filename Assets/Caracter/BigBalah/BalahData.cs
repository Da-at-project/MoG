using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalahData : MonoBehaviour
{
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        nowHP = maxHP;
        nowSP = maxSP;
    }

    void FixedUpdate()
    {
        if (Time.time > _nextTime)
        {
            _nextTime = Time.time + _pointTime;
            
            if (nowSP < maxSP) //spȸ��
                nowSP++;
            else
                nowSP = maxSP;

            if (nowSP < 0)
                nowSP = 0;

            if (nowHP > maxHP) //hp����
                nowHP = maxHP;
        }
    }

    public static BalahData instance;

    [Header("# balah Info")]
    public float maxHP = 100;

    public float nowHP;

    public float maxSP = 100;

    public float nowSP;

    [Header("# sp regen control")]
    private float _pointTime = 0.1f; // spȸ�� ������ �ð�

    private float _nextTime = 0.0f; // ������ ������ �ð�

}
