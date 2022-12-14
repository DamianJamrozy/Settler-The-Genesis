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
            if(collision.gameObject.TryGetComponent<Polyperfect.Animals.Animal_WanderScript>(out Polyperfect.Animals.Animal_WanderScript animal))
            {
                animal.TakeDamage(Controller.Instance.damage);
                if(collision.gameObject.TryGetComponent<DamageEnemy>(out DamageEnemy enemy))
                {
                    enemy.TakeDamage();
                }
            }
        }
        
    }
}
