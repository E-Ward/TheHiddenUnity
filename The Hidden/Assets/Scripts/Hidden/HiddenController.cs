using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HiddenController : MonoBehaviour
{
    public Health enemyHealth;

    public float range = 100f;
    public float force;
    public int pounceForce;

    public float hiddenHealth;
    public float hiddenStamina;
    public int attackDamage;

    Rigidbody rb;
    public Camera fpsCam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        hiddenHealth = 100f;
        hiddenStamina = 100f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))//This is when the left mouse button is pressed
        {
            Debug.Log("Player is Attacking");
            Attack();
        }

        if (Input.GetMouseButtonDown(1))//This is when the right mouse button is pressed
            {
                Debug.Log("Player is Pushing");
                Push();
            }

        if (Input.GetMouseButtonDown(2))//This is when the middle mouse button is pressed
        {
            Debug.Log("Player is Pouncing");
            Pounce();
        }

        if(hiddenStamina < 100)
        {
            hiddenStamina += 3 * Time.deltaTime;
        }
        
    }

    void Pounce()
    {
        if(hiddenStamina > 10)
        {
            rb.velocity = fpsCam.transform.forward * pounceForce;
            hiddenStamina -= 10f;
        }
        
    }


    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            enemyHealth.onDamage();
        }
    }

    void Push()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * force);
        }
    }
}
