using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    public int shotFragments = 8;
    public float spreadAngle = 10.0f;
    public float range = 100f;
    public float damage = 10f;
    public float fireRate = 15f;
    public float impactForce = 30f;


    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Text AmmoText;
    private float nextTimeToFire = 0f;



    public LayerMask layerMask = -1;
    public ParticleSystem muzleFlash;
    public GameObject impactEffect;
    public Camera fpsCam;

    private void Start()
    {
        currentAmmo = maxAmmo;


        AmmoText.text = maxAmmo.ToString();
    }
    void OnEnable()
    {
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = currentAmmo.ToString();
        if (isReloading)
            return;

        /*if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }*/

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && currentAmmo > 0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        currentAmmo--;
        muzleFlash.Play();
        for (int i = 0; i < shotFragments; i++)
        {
            RaycastHit hit;
            Quaternion fireRotation = Quaternion.LookRotation(transform.forward);
            Quaternion randomRotation = Random.rotation;

            fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(0.0f, spreadAngle));

            if(Physics.Raycast(transform.position, fireRotation * Vector3.forward, out hit,Mathf.Infinity))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 2f);
            }

        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
