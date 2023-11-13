using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBalahData : MonoBehaviour
{
    [Header("# balah Info")]
    public float maxHP = 100;
    public float nowHP;

    public float maxSP = 100;
    public float nowSP;

    [Header("# sp regen control")]
    private float _pointTime = 0.1f;
    private float _nextTime = 0.0f;

    private void Start()
    {
        nowHP = maxHP;
        nowSP = maxSP;
    }

    public class Scene
    {
        public bool[] notPlayed = { false, false, false };
    }
    public Scene scene;
}
