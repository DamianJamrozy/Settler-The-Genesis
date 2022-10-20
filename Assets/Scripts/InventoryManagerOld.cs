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
            inventory.SetActive(!inventory.activeInHierarchy);
            isOpen = !isOpen;
            minimap.SetActive(!minimap.activeInHierarchy);
            cover.SetActive(!cover.activeInHierarchy);

            InventoryManager.Instance.ListItems();
            InventoryManager.Instance.EnableItemsRemove();

            for (int i = 0; i < inventory.transform.childCount; i++)
            {
                

                
            }
            
        }
    }
}
