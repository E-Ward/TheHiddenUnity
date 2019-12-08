using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightRotate : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 updatedPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 updatedPos = transform.localPosition;
        updatedPos.z += 0.03f;
        transform.LookAt(target);
    }
}
