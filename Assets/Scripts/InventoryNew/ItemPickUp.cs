using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public float maxDistance = 5;
    public Camera cam;

    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }

    // void Update()
    // {

    //     if(InventoryManagerOld.instance.isOpen) return;

    //     RaycastHit hit;
    //     Ray ray = cam.ScreenPointToRay(Input.mousePosition);

    //     if(Physics.Raycast(ray, out hit, maxDistance))
    //     {
    //         if(hit.transform.TryGetComponent(out Item item))
    //         {
    //             if(Input.GetMouseButtonDown(0))
    //             {
    //                 Pickup();
    //             }
    //         }
    //     }
    // }

    private void OnMouseDown()
    {
        Pickup();
    }

}
