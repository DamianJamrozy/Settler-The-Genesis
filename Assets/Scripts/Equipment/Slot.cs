using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    ItemsDataBase dataBase;
    public int ID;
    Image icon;

    Item item;

    void Start()
    {
        GetObjects();
        SetSlot();
    }

    public void SetSlot()
    {
        if(dataBase.playerItemDatabase[ID].itemName != "")
        {
            icon.gameObject.SetActive(true);
            icon.sprite = dataBase.playerItemDatabase[ID].texture;
        }else
        {
            icon.gameObject.SetActive(false);
            icon.sprite = null;
        }
    }

    void GetObjects()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
        dataBase = GameObject.Find("Manager").GetComponent<ItemsDataBase>();
    }
}
