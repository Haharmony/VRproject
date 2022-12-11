using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    static public int AmmoItemValue = 3;
    static public bool hasPickedUpAmmoItem = false;
    private bool hasEnteredTrigger = false;

    void Update()
    {
        if (hasEnteredTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPickedUpAmmoItem = true;
                hasEnteredTrigger = false;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hasEnteredTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        hasEnteredTrigger = false;
        hasPickedUpAmmoItem = false;
    }
//pato
}
