using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo_Crate : MonoBehaviour
{

    public int maxHeldAmmo;

    public int currentHeldAmmo;

    public Text AmmoText;

    // Start is called before the first frame update
    void Start()
    {
        currentHeldAmmo = maxHeldAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = currentHeldAmmo.ToString();
    }

    public void Ammo()
    {
       // if (currentHeldAmmo > 0)
        //{
            currentHeldAmmo -= 1;
        //}
        
    }
}
