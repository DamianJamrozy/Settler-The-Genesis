using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiBars : MonoBehaviour
{
    
    [Range(0, 100)] public float health = 100;
    [Range(0, 100)] public float food = 100;

    public float foodSpeed = 0.03f;
    public float healthSpeedAt5 = 0.05f;
    public float healthSpeedAt0 = 1f;

    public Image healthBar;
    public Image foodBar;

    public bool isSprint;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isSprint = Input.GetKey(KeyCode.LeftShift); 

        healthBar.fillAmount = health / 100;
        foodBar.fillAmount = food / 100;

        food -= foodSpeed * Time.deltaTime;

        if(food <= 5 && food >0){
            health -= healthSpeedAt5 * Time.deltaTime;
        }

        if(food <= 0){
            health -= healthSpeedAt0 * Time.deltaTime;
        }

    }
}
