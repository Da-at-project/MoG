
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inven : MonoBehaviour
{
    public Inven inven;
    public bool checkActive;
    private void Start()
    {
        inven = GetComponent<Inven>();
    }
    private void Awake()
    {
        inven.gameObject.SetActive(false);
        checkActive = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) & checkActive == false)
        {
            inven.gameObject.SetActive(true);
            checkActive = true;
        }

        if (Input.GetKeyDown(KeyCode.C) & checkActive == true)
        {
            inven.gameObject.SetActive(false);
            checkActive = false;
        }
    }
}