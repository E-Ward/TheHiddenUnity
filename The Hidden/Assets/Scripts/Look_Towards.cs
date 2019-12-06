using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_Towards : MonoBehaviour
{
    [Header("Look towards settings")]
    public GameObject target;
    public GameObject radarCamera;
    public Vector3 targetPoint;

    public Quaternion targetRotation;

    public Quaternion radarCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        radarCamera = GameObject.FindGameObjectWithTag("Radar Camera");
        target = GameObject.FindGameObjectWithTag("IRIS");
    }

    // Update is called once per frame
    void Update()
    {
        radarCameraRotation = radarCamera.transform.rotation;
        targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        targetRotation = radarCameraRotation; //Quaternion.LookRotation(-targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 150.0f);
    }
}
