using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentOpener : MonoBehaviour
{

    public GameObject equipmentUI;

    public bool isOpen;

    void Start()
    {
        equipmentUI.SetActive(false);
        isOpen = false;
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            isOpen = !isOpen;
            equipmentUI.SetActive(!equipmentUI.activeInHierarchy);

            

        }
    }
}
