using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatHp : MonoBehaviour
{
    public Slider mySlider;
    public float maxHp;
    public float curHp;

    private GameObject HpBar;
    void Start()
    {
        HpBar = GameObject.Find("RatCanvas/HpVar");
    }   

    private void LateUpdate()
    {
        mySlider.value = curHp / maxHp;
    }
    private void Update()
    {
        HpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, -1.2f, 0));
    }
}
