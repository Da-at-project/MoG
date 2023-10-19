using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items;

    [SerializeField]
    private Transform slotParent;
    [SerializeField]
    private Slot[] slots;
    int slotNum;
    private void OnValidate()
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    void Awake()
    {
        FreshSlot();
    }

    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }

    public void AddItem(ItemData _item)
    {
        for (int i = 0; i < 10; i++)
        {
            if (items[i] == null)
            {
                items[i] = _item;
                break;
            }
            if (i == 10)
            {
                Debug.Log("������ �����־��");
            }
        }
        FreshSlot();
    }

    public void UseItem(ItemData _item) 
    {

        if (_item.itemName == "Axe")
        {
            if (items[slotNum] != null)
            {
                items[slotNum] = null;
                FreshSlot();
                Debug.Log("���� ���");
            }
            else
            {
                Debug.Log("����־��");
            }
        }
    }

    public void CallUseItem(int qwe)
    {
        slotNum = qwe;
        
    }
}