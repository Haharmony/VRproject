using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalasInterfaz : MonoBehaviour
{
    public TMP_Text canvastex;
    public Gun gun;// Start is called before the first frame update
    void Start()
    {
        canvastex.text = gun.TotalBulletsString;
    }

    // Update is called once per frame
    void Update()
    {
        canvastex.text = gun.TotalBulletsString;
    }
}
