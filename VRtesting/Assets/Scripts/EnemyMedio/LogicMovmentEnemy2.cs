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

    public GameObject target;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.Find("Papa");
    }

    // Update is called once per frame
    void Update()
    {
        comportamientoEnemigo();
    }
    public void comportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position)>5) {
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
                animator.SetBool("walk", false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutine++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                animator.SetBool("walk", true);
                break;

        }
        }else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);
            animator.SetBool("walk", false);
            animator.SetBool("Run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
    }
}
