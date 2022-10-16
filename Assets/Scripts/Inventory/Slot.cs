using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Image Target;

    public Color32 normalColor;
    public Color32 enterColor;

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Target.color = enterColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Target.color = normalColor;
    }

    void Awake()
    {
        Target = GetComponent<Image>();
        Target.color = normalColor;
    }


    void GetObjects()
    {
        
    }
}
