using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HiddenController : MonoBehaviour
{
    public Health enemyHealth;

    public CharacterController characterController;

    public float range = 100f;
    public float force;
    public int pounceForce;

    public float throwForce = 40f;

    public float wallClingRange = 2;

    public float hiddenHealth;
    public float hiddenStamina;
    public int attackDamage;

    public bool isWallClinging;


    public float distanceToGround;
    public bool isGrounded = false;

    Rigidbody rb;
    public Camera fpsCam;

    public GameObject IRIS;
    public GameObject Grenade;

    void Start()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        IRIS = GameObject.FindGameObjectWithTag("IRIS");
        characterController = GetComponent<CharacterController>();
        enemyHealth = IRIS.GetComponent<Health>();
        rb = GetComponent<Rigidbody>();

        hiddenHealth = 100f;
        hiddenStamina = 100f;

        isWallClinging = false;
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))//This is when the left mouse button is pressed
        {
            Debug.Log("Player is Attacking");
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.G))//This is when the left mouse button is pressed
        {
            GrenadeThrow();
        }

        if (Input.GetMouseButtonDown(1))//This is when the right mouse button is pressed
            {
                Debug.Log("Player is Pushing");
                Push();
            }

        if (Input.GetMouseButtonDown(2))//This is when the middle mouse button is pressed
        {
            RaycastHit wallCling;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out wallCling, wallClingRange) && wallCling.transform.tag == "Wall" && isGrounded == false)
            {
                Debug.Log("Go to wallcling.");
                WallCling();
            }
            else
            {
                Debug.Log("Player is Pouncing");
                Pounce();
            }
            
            
        }

        
        if(!Physics.Raycast(transform.position, -Vector3.up,distanceToGround + 0.1f) )
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        if (hiddenStamina < 100 && isWallClinging == false)
        {
            hiddenStamina += 10 * Time.deltaTime;
        }

        if (hiddenStamina <= 0 && isWallClinging == true)
        {
            rb.isKinematic = false;
            characterController.enabled = true;
            isWallClinging = false;
        }

        if (hiddenStamina > 0 && isWallClinging == true)
        {
            hiddenStamina -= 5 * Time.deltaTime;
        }

    }



    void Pounce()
    {

        if (hiddenStamina > 10 && isWallClinging == true)
        {
            rb.isKinematic = false;
            characterController.enabled = true;
            rb.velocity = fpsCam.transform.forward * pounceForce;
            hiddenStamina -= 10f;
        }
        else if (hiddenStamina > 10 && isGrounded == true)
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

    void GrenadeThrow()
    {
        GameObject grenade = Instantiate(Grenade, fpsCam.transform.position, fpsCam.transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }

    void Push()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            hit.transform.GetComponent<Rigidbody>().AddForce(fpsCam.transform.forward * force);
        }
    }

    void WallCling()
    {
                rb.isKinematic = true;
                isWallClinging = true;
                characterController.enabled = false;
    }


}
