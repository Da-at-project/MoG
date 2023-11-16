
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenSc : MonoBehaviour
{
    public GameObject setActive;
    private bool isFalse = false;

    public void changeActive()
    {
        setActive.SetActive(isFalse = !isFalse);
    }
}