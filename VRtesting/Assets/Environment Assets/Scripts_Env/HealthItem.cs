using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public static int HealthItemValue = 25; //Valor que da el Item de vida
    public static bool hasPickedUpHealthItem = false; //Boolean para checar si el item ha sido recogido
    private bool hasEnteredTrigger = false; //Boolean para checar si el player está en el rango del item
    
    void Update()
    {
        if(hasEnteredTrigger) //Si hasEnteredTrigger es verdadero, has el siguiente if
        {
            if(Input.GetKeyDown(KeyCode.E)) //Si la tecla E es presionada, has lo siguiente
            {
                hasPickedUpHealthItem = true; //El item es recogido
                hasEnteredTrigger = false; //Se vuelve false ya que ya se tomó
                gameObject.SetActive(false); //Se apaga el item dando a entender que se ha tomado
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
        hasPickedUpHealthItem = false;
    }
}
