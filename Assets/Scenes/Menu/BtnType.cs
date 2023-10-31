using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public Transform buttonScale;

    public Camera Camera;
    public Canvas canvas;
    Image image;
    RectTransform rt;

    public Sprite sprite1;
    public Sprite sprite2;
    Vector2 mPos;
    bool isOn = false;

    void Awake()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (image == null || sprite1 == null || sprite2 == null) return;

        Vector2 lPos;
        mPos = Input.mousePosition;
        RectTransform rt2 = canvas.transform as RectTransform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt2, mPos, canvas.worldCamera, out lPos);
        Debug.Log(lPos);

        Debug.Log(rt.rect.x - rt.rect.width / 2);
        if (lPos.x > rt.sizeDelta.x-rt.rect.width/2  && lPos.x < transform.position.x+rt.rect.width/2
         && lPos.y > rt.sizeDelta.y-rt.rect.height/2 && lPos.y < transform.position.y+rt.rect.height/2)
        {
            isOn = true;  
        }
        else
        {
            isOn = false;
        }

        if (isOn && Input.GetMouseButtonDown(0))
        {
            image.sprite = sprite2;
            if (Input.GetMouseButtonDown(0))
            {
                Click();
            }
        }
        else
        {
            image.sprite = sprite1;
        }
    }

    void Click()
    {
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("New Game");
                SceneManager.LoadScene("BalahRoom");
                break;
            case BTNType.Continue:
                Debug.Log("Continue Game");
                break;
            case BTNType.Option:
                Debug.Log("Option");
                break;
            case BTNType.Quit:
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
                Debug.Log("Quit");
                break;
        }
    }
}
