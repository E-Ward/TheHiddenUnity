using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public GameObject[] trackedObjects;
    public GameObject[] trackedSonicAlarmObjects;
    

    List<GameObject> radarObjects;
    List<GameObject> borderObjects;
    List<GameObject> borderSonicAlarmObjects;
    List<GameObject> sonicAlarmObjects;


    public GameObject radarPrefab;
    public GameObject sonicAlarmPrefab;

    public float switchDistance;
    public Transform helpTransform;




    // Start is called before the first frame update
    void Start()
    {
        CreateRadarObjects();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i< radarObjects.Count; i++)
        {
            if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
            {
                //Switch to border objects
                helpTransform.LookAt(radarObjects[i].transform);
                //determins the correct position of the border object
                borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderObjects[i].layer = LayerMask.NameToLayer("Radar");
                radarObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                //switch to radar objects
                borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
                radarObjects[i].layer = LayerMask.NameToLayer("Radar");
            }
        }

        for (int i = 0; i < sonicAlarmObjects.Count; i++)
        {
            if (Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
            {
                //Switch to border objects
                helpTransform.LookAt(sonicAlarmObjects[i].transform);
                //determins the correct position of the border object
                sonicAlarmObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
                borderSonicAlarmObjects[i].layer = LayerMask.NameToLayer("Radar");
                sonicAlarmObjects[i].layer = LayerMask.NameToLayer("Invisible");
            }
            else
            {
                //switch to radar objects
                borderSonicAlarmObjects[i].layer = LayerMask.NameToLayer("Invisible");
                sonicAlarmObjects[i].layer = LayerMask.NameToLayer("Radar");
            }
        }
    }

    void CreateRadarObjects()
    {
        radarObjects = new List<GameObject>();
        borderObjects = new List<GameObject>();
        borderSonicAlarmObjects = new List<GameObject>();
        sonicAlarmObjects = new List<GameObject>();

        foreach (GameObject o in trackedObjects)
        {
            //Instantiate rader prefab at the position of tracked objects
            GameObject k = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            radarObjects.Add(k);

            GameObject j = Instantiate(radarPrefab, o.transform.position, Quaternion.identity) as GameObject;
            borderObjects.Add(j);
        }

        foreach (GameObject s in trackedSonicAlarmObjects)
        {
            GameObject l = Instantiate(sonicAlarmPrefab, s.transform.position, Quaternion.identity) as GameObject;
            sonicAlarmObjects.Add(l);

            GameObject j = Instantiate(radarPrefab, s.transform.position, Quaternion.identity) as GameObject;
            borderSonicAlarmObjects.Add(j);
        }
    }
}
