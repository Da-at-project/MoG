using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene2 : MonoBehaviour
{
    public string NextSceneName;

    public float setTime;
    public float time;
    
    void Start()
    {
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= setTime)
        {
            GameObject rat = GameObject.Find("GiantRat");
            if(rat == null)
                SceneManager.LoadScene(NextSceneName);
        }
    }
}
