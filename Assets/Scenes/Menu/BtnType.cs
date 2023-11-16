using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnType : MonoBehaviour, IPointerClickHandler
{
    public BTNType currentType;
    public Transform buttonScale;

    public Camera Camera;
    public Canvas canvas;
    Image image;
    RectTransform rt;

    public Vector2 w;
    public Sprite sprite1;
    public Sprite sprite2;
    Vector2 mPos;
    bool isOn = false;

    AudioSource audioSource;

    void Awake()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (image == null || sprite1 == null || sprite2 == null) 
            return;

        Vector2 lPos;
        mPos = Input.mousePosition;
        RectTransform rt2 = canvas.transform as RectTransform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt2, mPos, canvas.worldCamera, out lPos);
        lPos.x += w.x;
        lPos.y += w.y;
        Debug.Log(lPos);
        Debug.Log(rt.sizeDelta);
        Debug.Log(rt.rect);

        Debug.Log(rt.rect.x - rt.rect.width / 2);
        if (lPos.x > rt.sizeDelta.x-rt.rect.width/2  && lPos.x < rt.sizeDelta.x+rt.rect.width/2
         && lPos.y > rt.sizeDelta.y-rt.rect.height/2 && lPos.y < rt.sizeDelta.y+rt.rect.height/2)
        {
            isOn = true;  
        }
        else
        {
            isOn = false;
        }

        if (isOn)
        {
            image.sprite = sprite2;
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();
                //Click();
                Invoke("Click", 0.2f);
            }
        }
        else
        {
            image.sprite = sprite1;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

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
