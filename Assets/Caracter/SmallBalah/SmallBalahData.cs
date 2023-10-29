using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBalahData : MonoBehaviour
{
    public static SmallBalahData instance = null;
    public static SmallBalahData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SmallBalahData>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SmallBalahData";
                    instance = go.AddComponent<SmallBalahData>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    [Header("# balah Info")]
    public float maxHP = 100;
    public float nowHP;

    public float maxSP = 100;
    public float nowSP;

    [Header("# sp regen control")]
    private float _pointTime = 0.1f;
    private float _nextTime = 0.0f;

    void Awake()
    {
        Debug.Log("Awake");
        if (instance != null) 
        {
            Destroy(gameObject); 
            return;
        }
        instance = this; 
        DontDestroyOnLoad(gameObject);
    }

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
