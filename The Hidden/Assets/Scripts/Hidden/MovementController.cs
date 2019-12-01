/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{

    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public float currentSpeed;

    private float translation;
    private float straffe;

    public bool isGrounded;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        currentSpeed = walkSpeed;
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)

        translation = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);


        if (Input.GetKey(KeyCode.W) &&  Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            currentSpeed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = walkSpeed;
        }

        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }


        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}