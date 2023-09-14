using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private void Start()
    {
        fadeInOut.gameObject.SetActive(false);
    }
    public void DarkOnClick()
    {
        fadeInOut.gameObject.SetActive(true);
        Debug.Log("버튼눌름");
        StartCoroutine(FadeCoroutineDark());
    }

    public void LightOnClick()
    {
        Debug.Log("버튼눌름");
        StartCoroutine(FadeCoroutineLight());
    }
    IEnumerator FadeCoroutineDark()
    {

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeInOut.color = new Color(0, 0, 0, fadeCount);
        }

    }
    IEnumerator FadeCoroutineLight()
    {

        float fadeCount = 0;
        float rFadeCount = 1;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            rFadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fadeInOut.color = new Color(0, 0, 0, rFadeCount);
        }
        fadeInOut.gameObject.SetActive(false);
    }

    public static Fade instance;

    public Image fadeInOut;

    public GameObject button;

}
