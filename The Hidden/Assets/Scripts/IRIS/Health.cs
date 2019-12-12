using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Properties")]
    public int playerhealth; //This is the health used for when the player is alive
    public int playerDeadHealth; //This is the health used for when the player is dead and the hidden wants to feed on the corpse

    public bool isPlayerDead = false;

    [Header("Scripts")]
    public Hidden_Knife_Attack hidden_knife_attack;
    public HiddenController hiddenController;
    public Grenade grenadeController;
    public Molotov molotovController;


   
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = 100;
        playerDeadHealth = 35;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealth <= 0)
        {
            isPlayerDead = true;
            //Destroy(gameObject);
        }

        if (playerDeadHealth <= 0)
        {
            Debug.Log("Player is dead");
            //have some kind of gib effect here
            Destroy(gameObject);
        }
    }

    public void onDamage() //This gets called if the player is alive
    {
        playerhealth -= hidden_knife_attack.attackDamage;
    }

    public void onDeadDamage() //This gets called if the player is dead
    {
        playerDeadHealth -= hidden_knife_attack.deadAttackDamage;
        hiddenController.hiddenHealth += 5;
    }

    public void onMolotovDamage()
    {
        playerhealth -= molotovController.molotovDamage * (int)Time.deltaTime;
    }

    public void onExplosionDamage()
    {
        playerhealth -= grenadeController.explosionDamage;
    }

}
