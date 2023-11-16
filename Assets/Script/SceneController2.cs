using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SceneController2 : MonoBehaviour
{
    public static SceneController2 instance;
    private BalahMovement balah;

    private PlayableDirector pd;
    public TimelineAsset ta;

    public float waitTime = 0f;

    private void Start()
    {
        instance = this;
        balah = FindObjectOfType<BalahMovement>();
        pd = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "SmallBalah")
            startScene();
    }

    public void startScene()
    {
        Debug.Log("play");
        balah.Wait(waitTime);
        pd.Play(ta);
        //SmallBalahData.instance.scene.notPlayed[taID] = true;
    }
}
