using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    Rigidbody RB;
    public InventoryManagerOld im;
    public GuiBars gb;
    public Animator animator;

    public static Controller Instance;

    public GameObject sword;
    public GameObject bow;


    public Camera cam;

    public float moveSpeed = 0.1f;
    public float sprintSpeed = 0.3f;
    public float jumpForce = 16500;

    public float damage = 1f;

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

    bool isAiming;

    [Header("Aiming Settings")]
    RaycastHit hit;
    public LayerMask aimLayers;
    Ray ray;

    [Header("Head Rotation Settings")]
    public float lookAtPoint = 2.8f;

    public bool testAim;

    bool hitDetected;

    void Awake()
    {
        RB = GetComponent<Rigidbody>();
        Instance = this;

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
            if(Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isDancing", false);
                animator.SetBool("isRunning", true);
            }else if(Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isDancing", false);
                animator.SetBool("isRunning", false);
                animator.SetBool("isRunningBack", true);
            }
            
            RB.MovePosition((transform.position + (transform.forward) * vertical * sprintSpeed)); // + (transform.right * horizontal * moveSpeed)
            gb.food -= gb.foodSpeed * 5 * Time.deltaTime;
        }
        else
        {
            if(Input.GetKey(KeyCode.W)){
                animator.SetBool("isDancing", false);
                animator.SetBool("isWalking", true);
            }else if(Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isDancing", false);
                animator.SetBool("isWalking", false);
                animator.SetBool("isWalkingBack", true);
            }else
            {
                animator.SetBool("isWalkingBack", false);
                animator.SetBool("isWalking", false);
            }
            animator.SetBool("isRunningBack", false);
            animator.SetBool("isRunning", false);
            RB.MovePosition((transform.position + (transform.forward) * vertical * moveSpeed) ); // + (transform.right * horizontal * moveSpeed)
        }
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space) && gb.food > 5f)
        {
            isGrounded = false;
            animator.SetBool("isDancing", false);
            animator.SetBool("jump", true);
            StartCoroutine(Jump());
        }else
        {
            animator.SetBool("jump", false);
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

        if (Input.GetKey(KeyCode.D)){
            animator.SetBool("isDancing", true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("isAttacking", false);
        }


        isAiming = Input.GetButton("Fire2");


        if(testAim)
        {
            isAiming = true;
        }

        CharacterAim(isAiming);
        if(isAiming)
        {
            Aim();
            CharacterPullString(Input.GetButton("Fire2"));
            if(Input.GetButtonUp("Fire1"))
            {
                CharacterFireArrow();  
                if(hitDetected)
                {
                    Bow.Instance.Fire(hit.point);
                }else
                {
                    Bow.Instance.Fire(ray.GetPoint(300f));
                }
            }
            
        }else
        {
            DisableArrow();
            Release();
        }
    }

    public IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.5f);
        RB.AddForce(transform.up * jumpForce);
        gb.food -= 5f;
    }

    public void CharacterAim(bool aiming)
    {
        animator.SetBool("aim", aiming);
    }

    public void CharacterPullString(bool pull)
    {
        animator.SetBool("pullString", pull);
    }

    public void CharacterFireArrow()
    {
        animator.SetTrigger("fire");
    }

    public void Aim()
    {
        Vector3 camPosition = cam.transform.position;
        Vector3 dir = cam.transform.forward;

        ray = cam.ScreenPointToRay(Input.mousePosition);
        // ray = new Ray(camPosition, dir);
        if(Physics.Raycast(ray, out hit, 500f, aimLayers))
        {
            hitDetected = true;
        }else
        {
            hitDetected = false;
        }
    }

    public void Pull()
    {
        Bow.Instance.PullString();
    }

    public void EnableArrow()
    {
        Bow.Instance.PickArrow();
    }

    public void DisableArrow()
    {
        Bow.Instance.DisableArrow();
    }

    public void Release()
    {
        Bow.Instance.ReleaseString();
    }


}