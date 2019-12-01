using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Instantiate : MonoBehaviour
{
    public Camera fpsCam;
    public float throwForce = 40f;
    public GameObject Grenade;
    public GameObject Molotov;

    public void GrenadeThrow()
    {
        GameObject grenade = Instantiate(Grenade, fpsCam.transform.position, fpsCam.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    public void MolotovThrow()
    {
        GameObject molotov = Instantiate(Molotov, fpsCam.transform.position, fpsCam.transform.rotation);
        Rigidbody rb = molotov.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

}
