using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class SceneController9 : MonoBehaviour
{
    public static SceneController9 instance;
    private BalahMovement balah;

    private PlayableDirector pd;
    public TimelineAsset ta;

    public float waitTime = 0f;

    void Start()
    {
        instance = this;
        balah = FindObjectOfType<BalahMovement>();
        pd = GetComponent<PlayableDirector>();

        balah.Wait(waitTime);
        pd.Play(ta);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "SmallBalah")
        {
            Debug.Log("play");
            balah.Wait(waitTime);
            pd.Play(ta);
            //SmallBalahData.instance.scene.notPlayed[taID] = true;
        }
    }
}
