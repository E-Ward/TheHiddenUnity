using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    //List of game objects to be tracked by the radar
    public GameObject[] trackedObjects;
    //List of sonic alarm game objects to be tracked by the radar
    public GameObject[] trackedSonicAlarmObjects;
    

    List<GameObject> radarObjects;
    List<GameObject> borderObjects;


    List<GameObject> sonicAlarmObjects;
    List<GameObject> borderSonicAlarmObjects;
    
    //Gameobject prefab that apears above the tracked objects
    public GameObject radarPrefab;
    //Gameobject prefab that appears above the tracked sonic alarm
    public GameObject sonicAlarmPrefab;

    //This determins when to switch between the edge objects and the close objects
    public float switchDistance;

    //This transform is attached to the player so we can get a reference to where the player is.
    //I know I could have just used the players transform but I have done it this way now
    public Transform helpTransform;
    public Transform sonicHelpTransform;


    // Start is called before the first frame update
    void Start()
    {
        //Calls the function createRadar objects
        //This adds the radar object prefab above all of the tracked objects
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
            if (Vector3.Distance(sonicAlarmObjects[i].transform.position, transform.position) > switchDistance)
            {
                //Switch to border objects
                sonicHelpTransform.LookAt(sonicAlarmObjects[i].transform);
                //determins the correct position of the border object
                borderSonicAlarmObjects[i].transform.position = transform.position + switchDistance * sonicHelpTransform.forward; 
                
                //checks to see if the sonic alram has been tripped. If it has then it will display the icon

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

        sonicAlarmObjects = new List<GameObject>();
        borderSonicAlarmObjects = new List<GameObject>();
        

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

                GameObject h = Instantiate(sonicAlarmPrefab, s.transform.position, Quaternion.identity) as GameObject;
                borderSonicAlarmObjects.Add(h);
        }
    }
}
