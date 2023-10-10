using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public Transform buttonScale;

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("New Game");
                SceneManager.LoadScene("SampleScene");
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
