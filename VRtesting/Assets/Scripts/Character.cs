using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    float healt;
    float speed;

    public Character( float healt, float speed)
    {
        this.healt = healt;
        this.speed = speed;

    }

    public float Healt { get => healt; set => healt = value; }
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
        if( healt <= 0)
        {
            //Animacion morir
            //destruir
        }
    }

    
}
