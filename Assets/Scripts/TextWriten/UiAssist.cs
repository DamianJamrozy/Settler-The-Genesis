using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiAssist : MonoBehaviour
{
    public TextMeshProUGUI writtenTxt;

    void Awake()
    {
        writtenTxt = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>();
    }

    
    void Start()
    {
        writtenTxt.text = "Hello world";
    }
}
