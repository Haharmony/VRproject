using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ammo_Display : MonoBehaviour
{
    private int ammo = 6;
    public bool isFiring;
    public TextMeshProUGUI ammoDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = ammo.ToString ();
        if(Input.GetMouseButtonDown(0) && !isFiring && ammo >= 0)
        {
            isFiring = true;
            ammo--;
            isFiring = false;
            if(ammo <= 0)
            {
                ammo = 0;
            }
        }
    }
}
