using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAlarm : MonoBehaviour
{
    public AudioSource Alarm;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "IRIS" || player.gameObject.tag == "Hidden")
        {
            Alarm.Play();
            Alarm.loop = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        
        Alarm.loop = false;
    }
}
