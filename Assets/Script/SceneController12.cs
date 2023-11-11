using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SceneController12 : MonoBehaviour
{
    public static SceneController12 instance;
    private BalahMovement balah;

    private PlayableDirector pd;
    public TimelineAsset ta;

    GameObject inv;
    GameObject inv2;
    public float waitTime = 0f;
    private bool isEat;
    private bool isOpen;

    void Start()
    {
        instance = this;
        balah = FindObjectOfType<BalahMovement>();
        pd = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        inv2 = GameObject.Find("Inventory");
        inv = GameObject.Find("Inven");
        if (inv2 == null) return;


        if (inv2.GetComponent<Inventory>().items[0] == null)
            isEat = true;
        else
        {
            isEat = false;
        }
        
        Debug.Log("Open : " +  isOpen + ", Eat : " + isEat);

        if(isEat)
        {
            balah.Wait(waitTime);
            pd.Play(ta);
        }
    }
}
