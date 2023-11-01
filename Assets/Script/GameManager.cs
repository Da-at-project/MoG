using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject.SetActive(false);
            //ObjData objData = scanObject.GetComponent<>();
            //Talk(objData.id);
        }
    }
    /*
    void Talk(objData.id)   
    {
        string TalkData = TalkManager.GetTalk(id, talkIndex);

        if (TalkData != null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        talkText.text = TalkData;
        talkIndex++;
    }*/
}