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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
