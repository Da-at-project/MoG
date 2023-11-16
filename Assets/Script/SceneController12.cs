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

    public GameObject inv;
    public GameObject inv2;
    public float waitTime = 0f;
    private bool isEat;
    private bool isOpen;

    bool isPlay = false;

    void Start()
    {
        instance = this;
        balah = FindObjectOfType<BalahMovement>();
        pd = GetComponent<PlayableDirector>();
    }

    void Update()
    {
        if (isPlay) return;
        Debug.Log("Open : " + isOpen + ", Eat : " + isEat);
        if (inv.activeSelf == false)
            isOpen = true;
        else 
            isOpen = false;

        if (inv2.GetComponent<Inventory>().items[0] == null)
            isEat = true;
        else
        {
            isEat = false;
        }
        

        if(isEat && isOpen)
        {
            isPlay = true;
            balah.Wait(waitTime);
            pd.Play(ta);
        }
    }
}
