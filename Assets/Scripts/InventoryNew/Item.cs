using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName="Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public ItemType itemType;
    public Vector3 pickPosition;
    public Vector3 pickRotation;

    public enum ItemType
    {
        Food,
        Tool,
        Other
    }
}
