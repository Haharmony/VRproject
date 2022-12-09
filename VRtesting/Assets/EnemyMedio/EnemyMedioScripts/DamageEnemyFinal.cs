using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemyFinal : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        //funciona llamando la funcion de player3D para recibir daño en ñla voida del player
        if (other.tag =="Papa")
        {
            other.GetComponent<Player3D>().RecibirDano(damage);
        }
    }

}
