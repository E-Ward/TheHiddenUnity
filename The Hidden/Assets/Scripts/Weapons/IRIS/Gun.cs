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

    [Header("Laser sight properties")]
    public GameObject laserSightEffect;
    public float offset = 0.01f;

    [Header("Magazines")]
    public int Mag1;
    public int Mag2;
    public int Mag3;
    public int Mag4;

    [Header("Camera")]
    public Camera fpsCam;
    [Header("Particle")]
    public ParticleSystem muzleFlash;
    [Header("GameObjects")]
    public GameObject impactEffect;
    [Header("UI")]
    public Text AmmoText;


    private void Start()
    {
        currentAmmo = maxAmmo;

        Mag1 = maxAmmo;
        Mag2 = maxAmmo;
        Mag3 = maxAmmo;
        Mag4 = maxAmmo;

        AmmoText.text = maxAmmo.ToString();
    }

    void OnEnable()
    {
        isReloading = false;
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && currentAmmo >0 && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
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
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
