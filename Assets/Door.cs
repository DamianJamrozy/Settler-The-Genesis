using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Animator animator;
    public static Door Instance;
    bool isOpen;
    public Transform dorRotate;
    public Transform dorRotate2;
    public Transform dorRotate3;
    private bool canOpen = true;
    public GameObject player;


    void Start()
    {
        Instance = this;
        isOpen = false;
        player = GameObject.Find("Breathing Idle");
        InventoryManagerOld.instance.NoOpenDoor();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 0);

        float distance = Vector3.Distance(this.transform.position, player.transform.position);
        if(distance < 1.2f)
        {
            if(Input.GetKeyDown(KeyCode.Q))
                xD();
        }
    }

    void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InventoryManagerOld.instance.OpenDoor();
        }
    }

    public void xD()
    {
        if(isOpen)
        {
            close();
            //animator.SetBool("close",true);
        }else
        {
            open();
            //animator.SetBool("open",true);
        }
    }

    public void open()
    {
        Debug.Log("działa");
        this.transform.Rotate(0, 90, 0);
        isOpen = true;
        //animator.SetBool("close",false);
    }
    public void close()
    {
        Debug.Log("działa close");
        this.transform.Rotate(0, -90, 0);
        isOpen = false;
        //animator.SetBool("open",false);
    }
}
