using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody rb;
    BoxCollider bx;

    bool disableRotation;
    public float destroyTime = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();

        Destroy(this.gameObject, destroyTime);
    }

    void Update()
    {
        if(!disableRotation)
        {
            if(rb.velocity != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag !="Player")
        {
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;
        }
        
    }
}
