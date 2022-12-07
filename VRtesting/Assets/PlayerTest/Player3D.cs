using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3D : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Animator animator;
    public Transform eje;
    public bool inground;
    private RaycastHit Hit;
    public float distancia;
    public Vector3 v3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position + v3, transform.up*-1,out Hit, distancia))
        {
            if (Hit.collider.tag == "piso")
            {
                inground = true;

            }
            else
            {
                inground = false;
            }
        }
    }
     void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, Vector3.up * -1 * distancia);
    }
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 RotaTargetZ = eje.transform.forward;
        RotaTargetZ.y = 0;
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetZ), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            animator.SetBool("run", true);

        }
        else
        {
            if (inground)
            {
                rb.velocity = Vector3.zero;
                    }
            animator.SetBool("run", false);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetZ * -1), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            animator.SetBool("run", true);
           
        }
        Vector3 RotaTargetX = eje.transform.right;
        RotaTargetX.y = 0;
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetX), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            animator.SetBool("run", true);
          
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(RotaTargetX * -1), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
            animator.SetBool("run", true);

        }

    }
}
