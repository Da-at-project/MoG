using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private SmallBalahMovement smallBalah;

    private PlayableDirector pd;
    public TimelineAsset ta;

    public float waitTime = 0f;
    public int taID = 0;

    private void Start()
    {
        instance = this;
        smallBalah = FindObjectOfType<SmallBalahMovement>();
        pd = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "SmallBalah")
        {
            Debug.Log("play");
            smallBalah.Wait(waitTime);
            pd.Play(ta);
            //SmallBalahData.instance.scene.notPlayed[taID] = true;
        }
    }

}
