using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerhealth;

    public HiddenController hiddenController;
    public Grenade grenadeController;

    public Molotov molotovController;


   
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerhealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void onDamage()
    {
        playerhealth -= hiddenController.attackDamage;
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
