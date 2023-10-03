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
            case InfoType.HpText:
                if (EventSystem.current.IsPointerOverGameObject() == true ) // 마우스 커서 인식
                    myText.text = string.Format("{0:F0} / {1:F0}", BalahData.instance.nowHP, BalahData.instance.maxHP);
                else
                    myText.text = string.Format("");
                break;
            case InfoType.SpText:
                if (EventSystem.current.IsPointerOverGameObject() == true) // 마우스 커서 인식
                    myText.text = string.Format("{0:F0} / {1:F0}", BalahData.instance.nowSP, BalahData.instance.maxSP);
                else
                    myText.text = string.Format("");
                break;

        }
    }
    

    //변수
    public enum InfoType { Hp, HpText, Sp, SpText }

    public InfoType type;

    public Slider mySlider;

    Text myText;
}
