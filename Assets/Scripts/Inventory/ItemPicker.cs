using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    public float maxDistance;
    public Camera cam;

    void Update()
    {

        if(InventoryManager.instance.isOpen) return;

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.transform.TryGetComponent(out ItemObject item))
            {
                if(Input.GetMouseButtonDown(0))
                {
                    ItemsData.instance.playerItems.Add(ItemsData.instance.items[item.itemID]);

                    Destroy(item.gameObject);
                }
            }
        }
    }
}
