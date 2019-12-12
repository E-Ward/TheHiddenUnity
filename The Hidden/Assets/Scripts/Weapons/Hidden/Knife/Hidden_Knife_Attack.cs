using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Knife_Attack : MonoBehaviour
{
    public HiddenController hiddenMainController;

    public Health enemyHealth;

    public GameObject IRIS;

    public int attackDamage;
    public int deadAttackDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        IRIS = GameObject.FindGameObjectWithTag("IRIS");
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//This is when the left mouse button is pressed
        {
            if (enemyHealth.isPlayerDead == false)
            {
                Attack();
            }
            else if (enemyHealth.isPlayerDead == true)
            {
                DeadAttack();
            }
            
        }

    }

    public void Attack()
    {
        Debug.Log("Player is Attacking");
        RaycastHit hit;
        if (Physics.Raycast(hiddenMainController.fpsCam.transform.position, hiddenMainController.fpsCam.transform.forward, out hit, hiddenMainController.range) && hit.transform.tag == "IRIS")
        {
            enemyHealth.onDamage();
        }
    }

    public void DeadAttack()
    {
        Debug.Log("Player is Attacking a dead Iris member");
        RaycastHit hit;
        if (Physics.Raycast(hiddenMainController.fpsCam.transform.position, hiddenMainController.fpsCam.transform.forward, out hit, hiddenMainController.range) && hit.transform.tag == "IRIS")
        {
            enemyHealth.onDeadDamage();
        }
    }
}
