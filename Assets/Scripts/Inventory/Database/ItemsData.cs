using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsData : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Item> playerItems = new List<Item>();

    public static ItemsData instance;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

}

[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Tool,Food,Buildings,Others
    }

    public string name;
    public string desc;
    public int ID;
    public ItemType type;
    public Sprite icon;

    public Item(string name, string desc, int ID, ItemType type, Sprite icon)
    {
        this.name = name;
        this.desc = desc;
        this.ID = ID;
        this.type = type;
        this.icon = icon;
    }
}
