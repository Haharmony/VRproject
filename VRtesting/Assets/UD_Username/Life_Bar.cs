using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life_Bar : MonoBehaviour
{
    public float life;
    public Slider lifebar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.value = life;
        if (life < 1)
        {
            Destroy(gameObject);
        }
    }
}
