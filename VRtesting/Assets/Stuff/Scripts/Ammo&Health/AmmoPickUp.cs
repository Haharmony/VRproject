using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public int ammoBullets = 3;
    int newAmmo;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpBullets()
    {
        newAmmo += ammoBullets;
    }

    int AmmoAmount()
    {
        int newAmmo = GetComponent<Gun>().totalBullets;
    
        return newAmmo;
    }
}
