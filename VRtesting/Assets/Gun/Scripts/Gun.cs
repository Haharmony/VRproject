using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float enfrimaientoAux = 0;
    [SerializeField]
    float enfriamiento = 2;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    int maxCapacity = 6;
    [SerializeField]
    int actualbullets = 6;
    [SerializeField]
    Transform disparador;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Disparar(); 

    }


    //Instancia una bala en la puntita de la pistola
    void Disparar()
    {
        if (Input.GetKey(KeyCode.Space)) //Cambiar a control oculus
        {
            
            if (actualbullets > 0 && enfrimaientoAux <= 0) // Hay balas y esta frio
            {
                GameObject balaAux = GameObject.Instantiate(bullet, disparador.transform.position, disparador.transform.rotation);
                Destroy(balaAux, 2);
                enfrimaientoAux = enfriamiento;
                actualbullets--;
                //reproducir sonido disparo
            }
            else if (actualbullets > 0 && enfrimaientoAux > 0) //hay balas y caliente
            {
                enfrimaientoAux -=  Time.deltaTime;
                return;
            }
            else if (actualbullets <= 0 && enfrimaientoAux <= 0) //Sin balas frio
            {
                //sonido sin balas
                enfrimaientoAux = 0;
            }
            else if (actualbullets <= 0 && enfrimaientoAux > 0) //Con balas y caliente
                return;

        }
        else //sim no hay input
        {
            enfrimaientoAux -= Time.deltaTime;
            if (enfrimaientoAux <= 0)
                enfrimaientoAux = 0;
            return;
        }

    }

    //Recarga el arma
    int Recargar(int baseArmo)
    {
        int toReload = maxCapacity - actualbullets; 
        
        if(baseArmo < toReload)
        {
            maxCapacity += baseArmo;
           baseArmo = baseArmo - baseArmo;
        }
        else
        {
            maxCapacity += toReload;
            baseArmo -= toReload;
        }

        return baseArmo;
    }
}
