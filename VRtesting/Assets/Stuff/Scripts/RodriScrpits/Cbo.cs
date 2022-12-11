using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cbo : MonoBehaviour
{
    [SerializeField]
    float angle;
    [SerializeField]
    float speedturn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        angle += Time.fixedDeltaTime * speedturn;
        Vector4 q = Fisics.Quaternion(Vector3.up, angle);
        Quaternion quater = new Quaternion(q.x, q.y, q.z, q.w);
        this.transform.rotation = Fisics.SumaQuaternion(this.transform.rotation, quater);
    }
}
