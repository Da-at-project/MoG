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
    public TimelineAsset[] ta;

    private void Start()
    {
        instance = this;
        smallBalah = FindObjectOfType<SmallBalahMovement>();
        pd = GetComponent<PlayableDirector>();

        //smallBalah.Wait(12f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Scene")
        {
            
        }
        if(collision.gameObject.name == "SmallBalah")
        {
            Debug.Log("glgl");
            smallBalah.anim.Play("SmallBalahDead");
        }
        pd.Play(ta[0]);
        //collision.gameObject.SetActive(false);
        smallBalah.Wait(12f);
    }

}
