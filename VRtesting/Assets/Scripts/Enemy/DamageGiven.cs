using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiven : MonoBehaviour
{
    [SerializeField]
    float givenDamage;
    [SerializeField]
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Bullet")
        {
            enemy.GetDamage(givenDamage);
        }
    }
}
