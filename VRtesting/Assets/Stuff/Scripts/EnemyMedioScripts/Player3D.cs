using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{


    public static event Action OnPlayerDeath;
    //public Rigidbody rb;
    public float speed;
   // public Animator animator;
   // public Transform eje;
    //public bool inground;
    //private RaycastHit Hit;
    public float distancia;
    public Vector3 v3;
    public float playerHealth = 100 ;
    public bool EstoyMuerto = false;

    private float CurrentTimer = 0;
    private float TimeBetweenTicks = 1f;
    int TickDMG = 10;

    //public int playerHealth;
    public float maxHealth2 = 100;
    private int maxHealth = 100;
    private int minHealth = 0;

    public int baseAmmo;
    private int minBaseAmmo = 0;
    private int maxBaseAmmo = 6;
    //public Gun gun;

   // public GameObject flashlight;
    public bool boolFlashLight;

    LogicMovmentEnemy2 logicMovmentEnemy;

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
            //animator.SetBool("die", true);
            //animator.SetBool("run", false);
            //EstoyMuerto = true;
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
        //if (Physics.Raycast(transform.position + v3, transform.up*-1,out Hit, distancia))
        //{
        //    if (Hit.collider.tag == "piso")
        //    {
        //        inground = true;

        //    }
        //    else
        //    {
        //        inground = false;
        //    }
        //}


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


        //FLASHLIGHT FUNCTION
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    if (boolFlashLight == false)
        //    {
        //        flashlight.SetActive(true);
        //        Debug.Log("Pressing F");
        //        boolFlashLight = true;
        //    }
        //    else
        //    {
        //        flashlight.SetActive(false);
        //        boolFlashLight = false;
        //    }
        //}
    }

     void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, Vector3.up * -1 * distancia);
    }

    //private void FixedUpdate()
    //{
    //    Move();
    //}

    //void Move()
    //{
    //    //Funcion literal que sirve para mover a pápa
    //    if (!EstoyMuerto)
    //    {
    //        Vector3 RotaTargetZ = eje.transform.forward;
    //        RotaTargetZ.y = 0;

    //        if (Input.GetKey(KeyCode.W))
    //        {
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetZ), 0.3f);
    //            var dir = transform.forward * speed * Time.fixedDeltaTime;
    //            dir.y = rb.velocity.y;
    //            rb.velocity = dir;
    //            animator.SetBool("run", true);

    //        }
    //        else
    //        {
    //            if (inground)
    //            {
    //                rb.velocity = Vector3.zero;
    //            }
    //            animator.SetBool("run", false);

    //        }
    //        if (Input.GetKey(KeyCode.S))
    //        {
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetZ * -1), 0.3f);
    //            var dir = transform.forward * speed * Time.fixedDeltaTime;
    //            dir.y = rb.velocity.y;
    //            rb.velocity = dir;
    //            animator.SetBool("run", true);

    //        }
    //        Vector3 RotaTargetX = eje.transform.right;
    //        RotaTargetX.y = 0;
    //        if (Input.GetKey(KeyCode.D))
    //        {
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetX), 0.3f);
    //            var dir = transform.forward * speed * Time.fixedDeltaTime;
    //            dir.y = rb.velocity.y;
    //            rb.velocity = dir;
    //            animator.SetBool("run", true);

    //        }
    //        if (Input.GetKey(KeyCode.A))
    //        {
    //            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetX * -1), 0.3f);
    //            var dir = transform.forward * speed * Time.fixedDeltaTime;
    //            dir.y = rb.velocity.y;
    //            rb.velocity = dir;
    //            animator.SetBool("run", true);

    //        }

    //    }
    //}
  
    //void Reload()
    //{
    //    //gun.Reload(baseAmmo);
    //    //baseAmmo = gun.Recarga(baseAmmo);
    //}

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

    }


    void GameOver()
    {

    }
}
