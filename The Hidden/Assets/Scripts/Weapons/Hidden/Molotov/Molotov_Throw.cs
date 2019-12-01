using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov_Throw : MonoBehaviour
{
    public Grenade_Instantiate grenadeThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//This is when the left mouse button is pressed
        {

            grenadeThrow.MolotovThrow();
        }
    }
}

