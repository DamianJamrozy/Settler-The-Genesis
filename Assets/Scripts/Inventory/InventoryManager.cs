using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    GameObject inventory;
    public bool isOpen;
    public static InventoryManager instance;
    public GameObject minimap;
    public GameObject cover;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        inventory = transform.Find("Inventory").gameObject;
        isOpen = false;
        inventory.SetActive(false);
        minimap.SetActive(true);
        cover.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventory.SetActive(!inventory.activeInHierarchy);
            isOpen = !isOpen;
            minimap.SetActive(!minimap.activeInHierarchy);
            cover.SetActive(!cover.activeInHierarchy);

            for (int i = 0; i < inventory.transform.childCount; i++)
            {
                Slot slot = inventory.transform.GetChild(i).GetComponent<Slot>();

                slot.Target.color = slot.normalColor;
            }
            UpdateSlots();
        }

        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            ItemsData.instance.playerItems.Add(ItemsData.instance.items[0]);
            UpdateSlots();
        }

        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            ItemsData.instance.playerItems.Add(ItemsData.instance.items[1]);
            UpdateSlots();
        }

        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            ItemsData.instance.playerItems.Add(ItemsData.instance.items[2]);
            UpdateSlots();
        }
    }

    void UpdateSlots()
    {
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            if(i < ItemsData.instance.playerItems.Count)
            {
                inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(true);
                inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = ItemsData.instance.playerItems[i].icon;
            }else
            {
                inventory.transform.GetChild(i).Find("Icon").gameObject.SetActive(false);
                inventory.transform.GetChild(i).Find("Icon").GetComponent<Image>().sprite = null;
            }
        }
    }
}
