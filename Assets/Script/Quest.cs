using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Quest : MonoBehaviour, IPointerClickHandler
{
    public bool answer = true;
    public GameObject balah;
    public GameObject dir;

    void Update()
    {
        //Debug.Log("name : " + name + ", mouse : " + EventSystem.current.IsPointerOverGameObject());
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Mouse Click Button : Left");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("Mouse Click Button : Middle");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Mouse Click Button : Right");
        }

        Debug.Log("Mouse Position : " + eventData.position);
        Debug.Log("Mouse Click Count : " + eventData.clickCount);
        */
        Debug.Log(answer);

        if (answer)
        {
            SceneController2 scene = dir.GetComponent<SceneController2>();
            scene.startScene();
        }
        else
        {
            BalahMovement ba = balah.GetComponent<BalahMovement>();
            ba.Wait(0f);
        }
    }
}
