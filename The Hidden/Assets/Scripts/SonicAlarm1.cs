using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAlarm1 : MonoBehaviour
{
    private LineRenderer lr;
    public AudioSource Alarm;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "IRIS" || hit.collider.gameObject.tag == "Hidden")
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance));
                Alarm.Play();
                Alarm.loop = true;
            }
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
            Alarm.loop = false;
        }
    }
}
