using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController2 : MonoBehaviour
{
    public GameObject menu;
    public GameObject option;
    public GameObject image;
    public GameObject player;

    // private bool isMenuTrue = false;
    // private bool isOptionTrue = false;

    private float timer = 21f;

    private void Awake()
    {
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            //isMenuTrue = true;
            menu.SetActive(true);
            image.SetActive(true);
            player.SetActive(false);
        }
    }
}
