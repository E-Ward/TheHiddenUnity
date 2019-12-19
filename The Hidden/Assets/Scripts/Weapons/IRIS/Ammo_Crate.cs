using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo_Crate : MonoBehaviour
{

    public int maxHeldAmmo;

    public int currentHeldAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentHeldAmmo = maxHeldAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ammo()
    {
       // if (currentHeldAmmo > 0)
        //{
            currentHeldAmmo -= 1;
        //}
        
    }
}
