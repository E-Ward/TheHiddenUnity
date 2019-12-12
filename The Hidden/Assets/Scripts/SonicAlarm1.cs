using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicAlarm1 : MonoBehaviour
{
    private LineRenderer lr;
    public AudioClip Alarm;
    public AudioSource AudioSource;


    private bool isTripped;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        isTripped = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.DrawLine(transform.position, hit.point, Color.green);
            if (hit.collider)
            {
                lr.SetPosition(1, new Vector3(0, 0, hit.distance) * 4.8f);
                if (hit.collider.gameObject.tag == "IRIS" || hit.collider.gameObject.tag == "Hidden")
                {

                    if (isTripped == false)
                    {
                        AudioSource.PlayOneShot(Alarm);
                        isTripped = true;
                        StartCoroutine("WaitForSec");
                    }

                    
                    //AudioSource.loop = true;
                }
            }
            
        }
        else
        {
            lr.SetPosition(1, new Vector3(0, 0, 5000));
            isTripped = false;
            //AudioSource.loop = false;
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        isTripped = false;
    }
}
