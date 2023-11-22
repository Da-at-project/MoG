using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene2 : MonoBehaviour
{
    public string NextSceneName;

    public float setTime;
    public float time;

    public GameObject target;
    RatAI rat;
    
    void Start()
    {
        rat = target.GetComponent<RatAI>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time >= setTime)
        {
            if(rat.curHP <= 0)
                SceneManager.LoadScene(NextSceneName);
        }
    }
}
