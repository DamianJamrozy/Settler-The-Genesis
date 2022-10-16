using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDataBase : MonoBehaviour
{
    public List<Item> itemDataBase = new List<Item>();
    public List<Item> playerItemDatabase = new List<Item>();

    void Awake()
    {
        CreateDatabase();
    }

    void Update()
    {
        
    }

    void CreateDatabase()
    {
        //itemDataBase.Add(new Item("Apple", "Red apple", 0, Item.ItemType.food, 5, 20));
    }
}
