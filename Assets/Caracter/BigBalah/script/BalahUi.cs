using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BalahUi : MonoBehaviour
{
    private void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Hp:
                float curHp = BalahData.instance.nowHP;
                float maxHp = BalahData.instance.maxHP;
                mySlider.value = curHp / maxHp;
                break;
            case InfoType.Sp:
                float curSp = BalahData.instance.nowSP;
                float maxSp = BalahData.instance.maxSP;
                mySlider.value = curSp / maxSp;
                break;
        }
    }
    
    //º¯¼ö
    public enum InfoType { Hp, HpText, Sp, SpText }
    public InfoType type;

    public Slider mySlider;

    Text myText;
}