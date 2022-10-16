using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    ItemsDataBase dataBase;
    public EquipmentManager em;

    public int ID;
    Item item;

    Transform player;

    bool canPickup;

    public GameObject canPickUpInfo;

    void Start()
    {
        GetObjects();
        
        item = dataBase.itemDataBase[ID];
        canPickUpInfo.SetActive(false);
    }

    void Update()
    {
        if(Vector3.Distance(player.position, transform.position) < 10)
        {
            canPickup = true;
        }else 
        {
            canPickup = false;
        }
    }

    void OnMouseEnter()
    {
        if(canPickup)
        {
            canPickUpInfo.SetActive(true);
        }else
        {
            canPickUpInfo.SetActive(false);
        }
        
    }

    void OnMouseExit()
    {
        canPickUpInfo.SetActive(false);
    }

    void OnMouseOver() // while mouse is on object
    {
        if (canPickUpInfo && Input.GetKeyDown(KeyCode.Q))
        {
            PickUpItem();
        }
    }

    void PickUpItem()
    {
        for(int i = 0; i < dataBase.playerItemDatabase.Count; i++)
        {
            if(dataBase.playerItemDatabase[i].itemName == ""){
                dataBase.playerItemDatabase[i] = item;
                em.transform.GetChild(i).GetComponent<Slot>().SetSlot();
                break;
            }
        }
    }

    void GetObjects()
    {
        dataBase = GameObject.Find("Manager").GetComponent<ItemsDataBase>();
        player = GameObject.Find("Player_Hips").transform;
    }
}
