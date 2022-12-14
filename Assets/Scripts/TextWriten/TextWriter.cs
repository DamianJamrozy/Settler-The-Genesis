using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextWriter : MonoBehaviour
{

    public static TextWriter Instance;
    public TextMeshProUGUI whereWrite;

    public GameObject message;

    string txtToWrite;
    int charIndex;
    float timePC;
    private float timer;
    bool start = false;

    private void Awake()
    {
        Instance = this;
        message.SetActive(false);
    }

    public void AddWriter(string txtToWrite, float timePC){
        this.txtToWrite = txtToWrite;
        this.timePC = timePC;
        charIndex = 0;
        start = true;
        Time.timeScale = 0f;
        message.SetActive(true);
    }

    private void Update()
    {
        if(txtToWrite != null){
            timer -= Time.deltaTime;
            if(timer <= 0f){
                timer += timePC;
                charIndex++;
                whereWrite.text = txtToWrite.Substring(0, charIndex);

                if(charIndex >= txtToWrite.Length){
                    txtToWrite = null;
                    return;
                }
            }
            if(Input.GetButtonUp("Fire1")){
                    timePC = timePC/3;
            }
        }

        if(message.activeInHierarchy && txtToWrite == null)
        {
            if(Input.GetButtonUp("Fire1")){
                Time.timeScale = 1f;
                message.SetActive(false);
            }
        }
        
    }
}
