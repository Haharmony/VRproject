using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float velocity;
    [SerializeField]
    int damageBullet = 50;

    private void FixedUpdate()
    {
        Translate();
    }

    void Translate()
    {
        Vector3 direcion = this.transform.forward; //sacando direccion de disparo
        Vector3 deltaPosition = direcion * velocity * Time.deltaTime; //Cambio de posicion
        this.transform.position = Fisics.Translate(deltaPosition.x, deltaPosition.y, deltaPosition.z, this.transform.position); //Cambiando Posicion        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("destruyendo");
        Destroy(this.gameObject);
    }


}
