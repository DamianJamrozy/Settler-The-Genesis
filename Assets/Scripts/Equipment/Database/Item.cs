using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public enum ItemType
    {
        food,
        tool,
        building,
        other
    }

    public string itemName;
    public string itemDesc;
    public Texture2D texture;
    public int ID;
    public ItemType itemType;
    public float damage;
    public float foodAmount;
    public bool eatable;

    public Item(string itemName, string itemDesc, Texture2D texture, int ID, ItemType itemType, float damage, float foodAmount, bool eatable)
    {
        this.itemName = itemName;
        this.itemDesc = itemDesc;
        this.texture = texture;
        this.ID = ID;
        this.itemType = itemType;
        this.damage = damage;
        this.foodAmount = foodAmount;
        this.eatable = eatable;
    }
}
