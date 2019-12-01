using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class HiddenController : MonoBehaviour
{
    

    public MovementController hiddenController;

    public GameObject HiddenCanvas;

    public Grenade_Instantiate grenadeThrow;
    public Hidden_Knife_Attack hiddenKnifeAttack;

    public float range = 100f;
    public float force;
    public int pounceForce;

    public float wallClingRange = 2;

    public int hiddenHealth;
    public Text hiddenHealthText;
    public float hiddenStamina;
    public float hiddenMaxStamina = 100f;
    public Slider hiddenStaminaSlider;
    public int attackDamage;

    public bool isWallClinging;

    public float distanceToGround;
    public bool isGrounded = false;

    Rigidbody rb;
    public Camera fpsCam;

    void Start()
    {
        distanceToGround = GetComponent<Collider>().bounds.extents.y;

        
        hiddenController = GetComponent<MovementController>();
        
        rb = GetComponent<Rigidbody>();

        hiddenHealth = 100;
        hiddenHealthText.text = hiddenHealth.ToString();

        hiddenStamina = 100f;

        hiddenStaminaSlider.maxValue = hiddenMaxStamina;
        hiddenStaminaSlider.value = hiddenMaxStamina;

        isWallClinging = false;
        HiddenCanvas.SetActive(true);
    }

    void Update()
    {
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
            hiddenStamina += 3 * Time.deltaTime;
            hiddenStaminaSlider.value = hiddenStamina;
        }

        if (hiddenStamina <= 0 && isWallClinging == true)
        {
            rb.isKinematic = false;
            hiddenController.enabled = true;
            isWallClinging = false;
        }

        if (hiddenStamina > 0 && isWallClinging == true)
        {
            hiddenStamina -= 5 * Time.deltaTime;
            hiddenStaminaSlider.value = hiddenStamina;
        }

    }

    void Pounce()
    {

        if (hiddenStamina > 10 && isWallClinging == true)
        {
            rb.isKinematic = false;
            hiddenController.enabled = true;
            rb.velocity = fpsCam.transform.forward * pounceForce;
            hiddenStamina -= 10;
            isWallClinging = false;
            hiddenStaminaSlider.value = hiddenStamina;
        }
        else if (hiddenStamina > 10 && isGrounded == true)
        {
            rb.velocity = fpsCam.transform.forward * pounceForce;
            hiddenStamina -= 10;
            hiddenStaminaSlider.value = hiddenStamina;
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

    void WallCling()
    {
        rb.isKinematic = true;
        isWallClinging = true;
        hiddenController.enabled = false;
    }


}
