using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{


    public static event Action OnPlayerDeath;
    public static event Action StepInItem;
    
    public float speed;
 
    public float distancia;
    public Vector3 v3;
    public float playerHealth = 100 ;
    public bool EstoyMuerto = false;

    private float CurrentTimer = 0;
    private float TimeBetweenTicks = 1f;
    int TickDMG = 10;

    
    public float maxHealth2 = 100;
    private int maxHealth = 100;
    private int minHealth = 0;

    public int baseAmmo;
    private int minBaseAmmo = 0;
    private int maxBaseAmmo = 6;
  
    public bool boolFlashLight;

    LogicMovmentEnemy2 logicMovmentEnemy;

    public Gun gun;
    public AmmoPickUp AmmoP;


    public void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Arma"))
        {
            print("Recibi daño");
           
        }
        
    }
  
    public void RecibirDano(int damage)
    {
        playerHealth -= damage;
        print(playerHealth);
        if (playerHealth <= 0)
        {
           
            OnPlayerDeath?.Invoke();

        
        }
    }

    void Start()
    {
       // playerHealth = 100;
        baseAmmo = minBaseAmmo;
        boolFlashLight = false;

    }
    
    void Update()
    {
    


        //HEALTH PACK ITEM FUNCTION
        if (HealthItem.hasPickedUpHealthItem)
        {
            playerHealth = playerHealth + HealthItem.HealthItemValue;
            HealthItem.hasPickedUpHealthItem = false;

            if (playerHealth > maxHealth)
            {
                playerHealth = maxHealth;
            }
        }

        if (playerHealth <= minHealth)
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


        
    }

     void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, Vector3.up * -1 * distancia);
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
                playerHealth  -= TickDMG;
                CurrentTimer = 0;
                if(playerHealth <= 0)
                {
                    //animator.SetBool("die", true);
                    //animator.SetBool("run", false);
                    //EstoyMuerto = true;
                    OnPlayerDeath?.Invoke();
                }
            }

        }
        if (other.gameObject.tag == "Good Fog")
        {
            Debug.Log("Receiving DMG");
            TakeTickDamage();
            if (CurrentTimer >= TimeBetweenTicks)
            {
                playerHealth += TickDMG;
                CurrentTimer = 0;
                
            }

        }
        if(other.gameObject.tag == "Ammo")
        {

            TakeTickDamage();
            if (CurrentTimer >= TimeBetweenTicks)
            {
              
                CurrentTimer = 0;
                Debug.Log("Pick Up bullets");
                gun.actualbullets += AmmoP.ammoBullets;
            }
            
            //StepInItem?.Invoke();
        }

    }


    void GameOver()
    {

    }
}
