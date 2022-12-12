using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour
{
    public Image HealthBar;
    public Player3D p3d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    private void FixedUpdate()
    {
        HealthBar.fillAmount = p3d.playerHealth / p3d.maxHealth2;

       // Debug.Log(p3d.playerHealth);
        //Debug.Log(p3d.maxHealth2);
    }
    float HealthPlayerBar()
    {
       float Bar = GetComponent<Player3D>().playerHealth;
        return Bar;
    }
    float MaxHealthPlayer()
    {
        float MHP = GetComponent<Player3D>().maxHealth2;
        return MHP;
    }
}
