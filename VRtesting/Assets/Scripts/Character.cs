using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character :MonoBehaviour
{
    [SerializeField]
     float health;
    [SerializeField]
     float speed;

    public float Healt { get => health; set => health = value; }
    public float Speed { get => speed; set => speed = value; }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Walk()
    {

    }

    void Turn()
    {

    }

    void GetDamage()
    {

    }

    void Dead()
    {
        if( health <= 0)
        {
            //Animacion morir
            //destruir
        }
    }

    
}
