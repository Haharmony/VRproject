using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject target;
    public Vector3 v3;
    public float Speed;
    public float maxLook;
    public float minLook;
    public Quaternion camRotation;
    // Start is called before the first frame update
    void Start()
    {
        camRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Cam();
    }
    public void Cam()
    {
        if (target)
        {
            transform.position = target.transform.position + v3;
        }
        camRotation.y += Input.GetAxis("Mouse X") * Speed;
        camRotation.x += Input.GetAxis("Mouse Y") * Speed * -1;

        camRotation.x = Mathf.Clamp(camRotation.x, minLook, maxLook);
        transform.localRotation = Quaternion.Euler(camRotation.x, camRotation.y, camRotation.z);
    }
}
