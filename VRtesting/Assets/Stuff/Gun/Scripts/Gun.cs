using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
 //public float enfrimaientoAux = 0;
   
 //public   float enfriamiento = 2;
   
 public GameObject bullet;
   
 public int maxCapacity = 6;
   
 public  int actualbullets;
  
 public Transform disparador;

    
public bool SiDisparo;
public int totalBullets;
public int PickUpBullestGround = 0;
public string TotalBulletsString;

    // Start is called before the first frame update
    void Start()
    {
     
}

    // Update is called once per frame
    void Update()
    {
        totalBullets = actualbullets;
        TotalBulletsString = totalBullets.ToString();

        if (SiDisparo)
        {
            Disparar();
        }

    }


    //Instancia una bala en la puntita de la pistola
   public void Disparar()
    {
        
            
            if (actualbullets > 0 /*&& enfrimaientoAux <= 0*/) // Hay balas y esta frio
            {
                GameObject balaAux = GameObject.Instantiate(bullet, disparador.transform.position, disparador.transform.rotation);
                Destroy(balaAux, 2);
                //enfrimaientoAux = enfriamiento;
                actualbullets--;
                //reproducir sonido disparo
            }
            //else if (actualbullets > 0 /*&& enfrimaientoAux > 0*/) //hay balas y caliente
            //{
            //    enfrimaientoAux -=  Time.deltaTime;
            //    return;
            }
            //else if (actualbullets <= 0 && enfrimaientoAux <= 0) //Sin balas frio
            //{
            //    //sonido sin balas
            //    enfrimaientoAux = 0;
            //}
            //else if (actualbullets <= 0 && enfrimaientoAux > 0) //Con balas y caliente
            //    return;

        
    

    }
    //public void enfriamientoPistola()
    //{
    //    enfrimaientoAux -= Time.deltaTime;
    //    if (enfrimaientoAux <= 0)
    //        enfrimaientoAux = 0;
    //}

    //Recarga el arma
    //int Recargar(int baseArmo)
    //{
    //    int toReload = maxCapacity - actualbullets; 
        
    //    if(baseArmo < toReload)
    //    {
    //        maxCapacity += baseArmo;
    //       baseArmo = baseArmo - baseArmo;
    //    }
    //    else
    //    {
    //        maxCapacity += toReload;
    //        baseArmo -= toReload;
    //    }

    //    return baseArmo;
    //}

    //public int ammoBullets = 3;
 


    //private void OnPickeUp()
    //{
    //    Player3D.StepInItem += PickUpBullets;
    //}
    //private void OfPickeUp()
    //{
    //    Player3D.StepInItem -= PickUpBullets;
    //}

    //public void PickUpBullets()
    //{
    //    PickUpBullestGround += ammoBullets;
    //}

   

