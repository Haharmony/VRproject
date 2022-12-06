using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerITEMint : MonoBehaviour
{
    private float CurrentTimer = 0;
    private float TimeBetweenTicks = 1f;
    int TickDMG = 10;

    private int playerHealth = 100;
    private int maxHealth = 100;
    private int minHealth = 0;
    void Start()
    {
        
    }

    void Update()
    {
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
    }

    void TakeTickDamage()
    {
        CurrentTimer += Time.deltaTime;
    }

    private void OnCollisionStay(Collision collision) 
    {
        if(collision.gameObject.tag == "Contaminated Fog")
        {
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

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Contaminated Fog")
        {
            TakeTickDamage();
        }
    }
    //THIS CAN ALSO WORK BUT WE GOTTA MAKE PLAYER HEALTH A FLOAT, NOT AN INT. SAME WAY WITH TICKDMG BUT WE ARE WORKING WITH INTS.
     
    */
}
