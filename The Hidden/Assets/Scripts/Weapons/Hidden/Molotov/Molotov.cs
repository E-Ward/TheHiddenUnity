using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : MonoBehaviour
{

    public float delay = 3f;
   //public float blastRadius = 5f;
    //public float explosionForce = 700f;

    public int molotovDamage = 2;


    bool hasExploded = false;

    public GameObject molotovEffect;

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
        Instantiate(molotovEffect, transform.position, Quaternion.Euler(0, 0, 0));
        StartCoroutine("WaitForSec");
        //Collider [] colliders = Physics.OverlapSphere(transform.position, blastRadius);

        //Destroy(gameObject);
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
