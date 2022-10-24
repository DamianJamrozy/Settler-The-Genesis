using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;

    public void Awake()
    {
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);

        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch(item.itemType)
        {
            case Item.ItemType.Food:
                GuiBars.Instance.food += item.value;
                break;
            case Item.ItemType.Tool:
                if(Controller.Instance.bow.activeInHierarchy)
                {
                    Controller.Instance.bow.SetActive(false);
                }
                Controller.Instance.sword.SetActive(true);
                Controller.Instance.damage += item.value;
                
                break;
            case Item.ItemType.Other:
                if(Controller.Instance.sword.activeInHierarchy)
                {
                    Controller.Instance.sword.SetActive(false);
                }
                Controller.Instance.bow.SetActive(true);
                
                break;
        }

        RemoveItem();
    }
}
