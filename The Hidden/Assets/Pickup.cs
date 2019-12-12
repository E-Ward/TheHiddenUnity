using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    float throwforce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isHolding ==true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if(Input.GetMouseButtonDown(1))
            {

            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;

    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}
