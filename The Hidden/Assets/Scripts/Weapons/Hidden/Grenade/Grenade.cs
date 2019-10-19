using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3f;
    public float blastRadius = 5f;
    public float explosionForce = 700f;

    public int explosionDamage = 50;


    bool hasExploded = false;

    public GameObject explosionEffect;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider [] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        foreach (Collider nearbyObjects in colliders)
        {
            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, blastRadius);
            }
            
            Health playerHealth = nearbyObjects.GetComponent<Health>();
            if(playerHealth != null)
            {
                playerHealth.onExplosionDamage();
            }
        }
        Destroy(gameObject);
    }
}
