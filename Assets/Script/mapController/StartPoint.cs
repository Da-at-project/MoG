using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    public string beforeMap;
    private SmallBalahMovement smallBalah;

    void Start()
    {
        smallBalah = FindObjectOfType<SmallBalahMovement>();

        if(startPoint == smallBalah.currentMap
        && beforeMap == smallBalah.beforeMap)
        {
            smallBalah.transform.position = this.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("enter");
        smallBalah.beforeMap = smallBalah.currentMap;
        smallBalah.currentMap = beforeMap;
        SceneManager.LoadScene(beforeMap);
    }
}
