using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCling : MonoBehaviour
{
    Rigidbody rb;
    public GameObject hidden;

    // Start is called before the first frame update
    void Start()
    {
        hidden = GameObject.FindGameObjectWithTag("Hidden");
        rb = hidden.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(2))//This is when the middle mouse button is pressed
        {
            Debug.Log("Player is Clinging");
            rb.isKinematic = true;
                //attachedRigidbody.isKinematic = true;
        }
    }*/

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Player is Clinging");
        rb.isKinematic = true;
    }


}
