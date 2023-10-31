using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;

    // private bool isMenuTrue = false;
    // private bool isOptionTrue = false;

    private float timer = 20f;

    void FixedUpdate()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        } 
        else
        {
            //isMenuTrue = true;
            menu.SetActive(true);
        }

    }
}
