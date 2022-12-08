using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerITEMint : MonoBehaviour
{
    private float CurrentTimer = 0;
    private float TimeBetweenTicks = 1f;
    int TickDMG = 10;

    public int playerHealth;
    private int maxHealth = 100;
    private int minHealth = 0;

    public int baseAmmo;
    private int minBaseAmmo = 0;
    private int maxBaseAmmo = 6;
    //public Gun gun;

    public GameObject flashlight;
    public bool boolFlashLight = false;
    

    void Start()
    {
        playerHealth = maxHealth;
        baseAmmo = minBaseAmmo;
        flashlight.SetActive(false);
    }

    void Update()
    {

        //HEALTH PACK ITEM FUNCTION
        if(HealthItem.hasPickedUpHealthItem)
        {
            playerHealth = playerHealth + HealthItem.HealthItemValue;
            HealthItem.hasPickedUpHealthItem = false;

            if(playerHealth > maxHealth)
            {
                playerHealth = maxHealth;
            }
        }

        if(playerHealth <= minHealth)
        {
            playerHealth = minHealth;
            GameOver();
        }

        //AMMO PACK ITEM FUNCTION
        if (AmmoItem.hasPickedUpAmmoItem)
        {
            baseAmmo = baseAmmo + AmmoItem.AmmoItemValue;
            AmmoItem.hasPickedUpAmmoItem = false;

            if (baseAmmo > maxBaseAmmo)
            {
                baseAmmo = maxBaseAmmo;
            }
        }

        if (baseAmmo <= minBaseAmmo)
        {
            baseAmmo = minBaseAmmo;
        }


        //FLASHLIGHT FUNCTION
        if (Input.GetKeyDown(KeyCode.F))
       {
            if (boolFlashLight == false)
            {
                flashlight.SetActive(true);
                Debug.Log("Pressing F");
                boolFlashLight = true;
            }
            else
            {
                flashlight.SetActive(false);
                boolFlashLight = false;
            }
        }
    }

    void Reload()
    {
        //gun.Reload(baseAmmo);
        //baseAmmo = gun.Recarga(baseAmmo);
    }

    void TakeTickDamage()
    {
        CurrentTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Contaminated Fog")
        {
            Debug.Log("Receiving DMG");
            TakeTickDamage();
            if (CurrentTimer >= TimeBetweenTicks)
            {
                playerHealth = playerHealth - TickDMG;
                CurrentTimer = 0;
            }

        }
    }

    void GameOver()
    {

    }

    /*
    void TakeTickdamage()
    {
        playerHealth -= TickDMG * Time.deltaTime;
    }

    private void OnTriggerStay(Collision other)
    {
        if(other.gameObject.tag == "Contaminated Fog")
        {
            TakeTickDamage();
        }
    }
    //THIS CAN ALSO WORK BUT WE GOTTA MAKE PLAYER HEALTH A FLOAT, NOT AN INT. SAME WAY WITH TICKDMG BUT WE ARE WORKING WITH INTS. AND IT WILL TALE DMG PER SEC.

    ON COLLISION STAY EXAMPLE:
    - PUSHING AN OBJECT AND MOVING IT AS LONG AS BOTH COLLIDERS COLLIDE (IS NOT TRIGGER COLLIDER). (RIGIDBODY REQUIERED)

    ON TRIGGER STAY EXAMPLE:
    - OUT OF THE SAFE AREA AND A COUNTDOWN STARTS, IF IT REACHES 0 YOU DIE. THIS COUNTDOWN STARTS WHEN IT DETECTS AN OBJECT INSIDE OF ANOTHER OBJECT (IS TRIGGER COLLIDER). (RIGIDBODY REQUIERED)
     
    */
}
