using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManagerOld : MonoBehaviour
{
    GameObject inventory;
    public bool isOpen;
    public static InventoryManagerOld instance;
    public GameObject minimap;
    public GameObject cover;
    public GameObject txt;
    public GameObject quests;
    public TextMeshProUGUI questCounter;


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
        quests.SetActive(false);
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            questCounter.text = Controller.Instance.questCounter.ToString();
            if(isOpen)
            {
                inventory.SetActive(false);
                isOpen = false;
                minimap.SetActive(true);
                cover.SetActive(false);
                quests.SetActive(false);
                InventoryManager.Instance.RemoveItemsInventory();
                
            }else
            {
                inventory.SetActive(true);
                isOpen = true;
                minimap.SetActive(false);
                cover.SetActive(true);
                quests.SetActive(true);
                InventoryManager.Instance.ListItems();
                InventoryManager.Instance.EnableItemsRemove();
            }
            
        }
    }

    public void OpenDoor()
    {
        Debug.Log("xD");
        txt.SetActive(true);
    }
    
    public void NoOpenDoor()
    {
        Debug.Log("2222");
        txt.SetActive(false);
    }
}
