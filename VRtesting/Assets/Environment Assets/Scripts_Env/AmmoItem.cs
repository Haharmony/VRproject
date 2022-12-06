using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    private int AmmoItemValue = 5;
    public static bool hasPickedUpAmmoItem = false;
    private bool hasEnteredTrigger = false;

    public void Value()
    {
        AmmoItemValue = 25;
    }

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
}
