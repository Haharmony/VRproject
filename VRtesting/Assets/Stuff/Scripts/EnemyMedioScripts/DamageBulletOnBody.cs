    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBulletOnBody : MonoBehaviour
{

    public string ParteDelCuerpo;
    public string bala;
   public LogicMovmentEnemy2 logicMovment;
    private void OnTriggerEnter(Collider coll)
    {
        if (ParteDelCuerpo == "Body")
        {
            if (coll.CompareTag(bala))
            {
                logicMovment.EnemyLife -= 50;
                print(logicMovment.EnemyLife);
            }

        }
        else if(ParteDelCuerpo == "Head")
        {
            if (coll.CompareTag(bala))
            {
                logicMovment.EnemyLife -= 100;
                print(logicMovment.EnemyLife);
            }
        }

    }
  //Se piden don strings, la primera es para ver en que parte del cuerpo esta recibiendo daño ya sea body o head, el segundo string es para ver que tipo de bala le afecta 
}
