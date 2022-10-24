using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManagerOld : MonoBehaviour
{
    GameObject inventory;
    public bool isOpen;
    public static InventoryManagerOld instance;
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
            if(isOpen)
            {
                inventory.SetActive(false);
                isOpen = false;
                minimap.SetActive(true);
                cover.SetActive(false);
                InventoryManager.Instance.RemoveItemsInventory();
                
            }else
            {
                inventory.SetActive(true);
                isOpen = true;
                minimap.SetActive(false);
                cover.SetActive(true);
                InventoryManager.Instance.ListItems();
                InventoryManager.Instance.EnableItemsRemove();
            }
            

            // for (int i = 0; i < inventory.transform.childCount; i++)
            // {
                

                
            // }
            
        }
    }
}
