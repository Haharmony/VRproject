using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicMovmentEnemy2 : MonoBehaviour
{
    public int rutine;
    public float cronometro;
    public Animator animator;
    public Quaternion angulo;
    public float grado;
    public float DistanceToHit;
    public GameObject target;
    public int EnemyLife;
    public int Damage;
    public bool CloseToProta = true;
    

    public bool Atacando;
   // BalaTest balatest;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("XR Origin"); //el target va a ser el gameobject que tenga el nombre de papa
    }

    public void comportamientoEnemigo()
    {
        if (CloseToProta)
        {

            if (Vector3.Distance(transform.position, target.transform.position) > 5)
            {

                animator.SetBool("Run", false);
                cronometro += 1 * Time.deltaTime;
                if (cronometro >= 4)
                {
                    rutine = Random.Range(0, 2);
                    cronometro = 0;
                }
                switch (rutine)
                {
                    case 0:
                        animator.SetBool("walk", true);
                        break;
                    case 1:
                        grado = Random.Range(0, 360);
                        angulo = Quaternion.Euler(0, grado, 0);
                        rutine++;
                        break;
                    case 2:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                        animator.SetBool("walk", false);
                        break;

                }
            }
            else
            {
                if (Vector3.Distance(transform.position, target.transform.position) > DistanceToHit && !Atacando)
                {
                    var lookPos = target.transform.position - transform.position;
                    lookPos.y = 0;
                    var rotation = Quaternion.LookRotation(lookPos);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
                    animator.SetBool("walk", false);

                    animator.SetBool("Run", true);
                    transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                    animator.SetBool("attack", false);
                }
                else
                {
                    animator.SetBool("walk", false);
                    animator.SetBool("Run", false);
                    animator.SetBool("attack", true);
                    Atacando = true;

                }
            }

            if (EnemyLife <= 0)
            {
                CloseToProta = false;
                MuerteEnemigo();
            }
        }
    }

    public void MuerteEnemigo()
    {
        animator.SetBool("walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("attack", false);
        animator.SetBool("Die", true);
        Destroy(this.gameObject, 5);
    }
    public void animacionFinal()
    {
        animator.SetBool("attack", false);
        Atacando = false;
    }

  

    void Update()
    {
        comportamientoEnemigo();
    }


    
}