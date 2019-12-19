using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Properties")]
    public float damage = 10f;
    public int maxAmmo = 10;
    public float reloadTime = 1f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;
    private float nextTimeToFire = 0f;
    private int currentAmmo;
    private bool isReloading = false;
    private bool isFlashlightOn = false;

    [Header("Laser sight properties")]
    public GameObject laserSightEffect;
    public float offset = 0.01f;

    [Header("Magazine")]
    public int MagazineTotal;
    public int currentAmountOfMags;

    [Header("Camera")]
    public Camera fpsCam;
    [Header("Particle")]
    public ParticleSystem muzleFlash;
    [Header("GameObjects")]
    public GameObject impactEffect;
    public GameObject torchLight;
    public GameObject outOfAmmoText;
    [Header("UI")]
    public Text AmmoText;


    private void Start()
    {
        currentAmmo = maxAmmo;

        AmmoText.text = maxAmmo.ToString();

        currentAmountOfMags = MagazineTotal;

        outOfAmmoText.SetActive(false);
    }

    void OnEnable()
    {
        isReloading = false;
        isFlashlightOn = false;
        torchLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit laserSightHitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out laserSightHitInfo,range))
        {

            // Vector3 updatedPos = laserSightEffect.transform.localPosition;
            //updatedPos = laserSightHitInfo.point;

            //Debug.Log(laserSightHitInfo.transform.name);

            laserSightEffect.transform.position = laserSightHitInfo.point + laserSightHitInfo.normal*offset;
            //GameObject impactLaserSight = Instantiate(laserSightEffect, laserSightHitInfo.point, Quaternion.LookRotation(laserSightHitInfo.normal));
            //Destroy(impactLaserSight, 2f);
        }

        AmmoText.text = currentAmmo.ToString();
        if (isReloading)
            return;

        /*if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }*/

        if (Input.GetKeyDown(KeyCode.R) && currentAmountOfMags > 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlashlightOn == false)
            {
                torchLight.SetActive(true);
                isFlashlightOn = true;
            }
            else if (isFlashlightOn == true)
            {
                torchLight.SetActive(false);
                isFlashlightOn = false;
            }
        }

        if (Input.GetButton("Fire1") && currentAmmo >0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if(currentAmountOfMags <= 0 && currentAmmo <= 0)
        {
            outOfAmmoText.SetActive(true);
        }
        else
        {
            outOfAmmoText.SetActive(false);
        }
    }

    void Shoot()
    {
        currentAmmo--;
        muzleFlash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(impactGo, 2f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        currentAmountOfMags -= 1;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
