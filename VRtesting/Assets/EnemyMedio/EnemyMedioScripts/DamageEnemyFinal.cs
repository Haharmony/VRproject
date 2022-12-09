using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyFinal : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Papa")
        {
            other.GetComponent<Player3D>().RecibirDano(damage);
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
