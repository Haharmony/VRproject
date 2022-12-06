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


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void comportamientoEnemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutine = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutine)
        {
            case 0:
                animator.SetBool("WalkEnemy2", false);
                break;
        }
    }
}
