using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public int ammoBullets = 3;
    int newAmmo;
    public Gun gun;

   

    private void OnPickeUp()
    {
        Player3D.StepInItem += PickUpBullets;
    }
    private void OfPickeUp()
    {
        Player3D.StepInItem -= PickUpBullets;
      
    }

    public void PickUpBullets()
    {
        Debug.Log("Hola");

        gun.actualbullets += ammoBullets;
        
    }

    int AmmoAmount()
    {
        int newAmmo = GetComponent<Gun>().totalBullets;
    
        return newAmmo;
    }
}
