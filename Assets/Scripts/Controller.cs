using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Rigidbody RB;
    public InventoryManager im;
    public GuiBars gb;

    GameObject cam;

    public float moveSpeed = 0.1f;
    public float sprintSpeed = 0.3f;
    public float jumpForce = 16500;

    public bool inSprint;

    public float mouseSensitivity = 2;

    float vertical;
    float horizontal;

    public float mouseX;
    public float mouseY;

    public bool isGrounded = true;
    public float groundCheckDistance;
    public float bufferCheckDistance = 0.01f;

    float camRotX;

    public float maxRotX = 45;

    public Transform player;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        cam = transform.Find("Camera").gameObject;
    }
    
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        inSprint = Input.GetKey(KeyCode.LeftShift);

        groundCheckDistance = 1 + bufferCheckDistance;

        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, groundCheckDistance))
        {
            isGrounded = true;
        }else
        {
            isGrounded = false;
        }

        if(inSprint && isGrounded && gb.food > 0.5f) 
        {
            RB.MovePosition((transform.position + (transform.forward) * vertical * sprintSpeed) + (transform.right * horizontal * moveSpeed));
            gb.food -= gb.foodSpeed * 5 * Time.deltaTime;
        }
        else
        {
            RB.MovePosition((transform.position + (transform.forward) * vertical * moveSpeed) + (transform.right * horizontal * moveSpeed));
        }
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space) && gb.food > 5f)
        {
            isGrounded = false;
            RB.AddForce(transform.up * jumpForce);
            gb.food -= 5f;
        }

        if(mouseX == 0)
        {
            RB.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            RB.constraints = RigidbodyConstraints.None;
            RB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        }

        RB.MoveRotation(RB.rotation * Quaternion.Euler(new Vector3(0, mouseX * mouseSensitivity, 0)));

        if(im.isOpen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;
        }else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Time.timeScale = 1;
            camRotX -= mouseY * mouseSensitivity;
            camRotX = Mathf.Clamp(camRotX, -maxRotX, maxRotX);
            Quaternion camRot = Quaternion.Euler(camRotX, 0, 0);
            cam.transform.localRotation = camRot;
        }
    }


}