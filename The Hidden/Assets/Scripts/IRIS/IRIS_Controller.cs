using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRIS_Controller : MonoBehaviour
{
    public DeferredNightVisionEffect nightVision;

    public bool isNightVisionActive;

    public float range = 100f;
    public Camera fpsCam;

    public Ammo_Crate ammo_crate;
    public Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        isNightVisionActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N) && isNightVisionActive == false)
        {
            isNightVisionActive = true;
            nightVision.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.N) && isNightVisionActive == true)
        {
            isNightVisionActive = false;
            nightVision.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            PickUpAmmo();
        }
    }

    public void PickUpAmmo()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, range) && hit.transform.tag == "Ammo Box")
        {
            if(gun.currentAmountOfMags < gun.MagazineTotal && ammo_crate.currentHeldAmmo > 0)
            {
                ammo_crate.Ammo();
                gun.currentAmountOfMags += 1;
            }
            
        }
    }
}
