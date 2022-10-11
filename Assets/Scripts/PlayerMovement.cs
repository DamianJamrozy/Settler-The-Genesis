using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerRotationSpeed = 100.0f;
    public float _jumpForce = 200.0f;
    public Rigidbody _rb;

    private float ySpeed;
    
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);

        if(Input.GetKeyDown(KeyCode.Space)) _rb.AddForce(Vector3.up * _jumpForce);

    }
}
