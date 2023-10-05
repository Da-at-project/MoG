
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSc : MonoBehaviour
{

    public GameObject setActive;
    private bool isFalse = false;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            setActive.SetActive(isFalse = !isFalse);
        }
    }
}