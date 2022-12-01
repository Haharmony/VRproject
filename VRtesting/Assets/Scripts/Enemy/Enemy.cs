
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField]
    float damage;
    GameObject player;
    RaycastHit hit;
    Ray ray;

    float distance;

    public Enemy(float health, float speed)
    {
        Healt = health;
        Speed = speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Fisics.Distance(this.transform, player.GetComponent<Transform>());
        
    }
    void FixedUpdate()
    {
        Vector3 fordward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(this.transform.position, fordward, 10))
            print("There is something in front of the object!");
    }

    void MoveToPlayer()
    {
        ray = new Ray(this.transform.position, Vector3.forward);
        

        //rotate
        if (Physics.Raycast(ray, out hit))
        {
            string name = hit.transform.name;

            if (name != "Player")
            {
                Vector4  q = Fisics.Quaternion(Vector3.up, 27.35f);
                this.transform.rotation = new Quaternion(q.x, q.y, q.z, q.w);
            }
        }

        //walk
        if(distance > 15f)
        {
            //avanzar al player
        }
        else
        {
            //quedarse quieto
        }

    }

    void Attack()
    {
        if (distance < 1f)
        {
            //Atacar (animacion)
            //activar audio
        }
    }

    public void GetDamage(float damage)
    {
        Healt -= damage;
    }


}
