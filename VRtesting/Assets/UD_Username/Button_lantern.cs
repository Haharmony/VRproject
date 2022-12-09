using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_lantern : MonoBehaviour
{

    public TextMeshProUGUI Buttonlantern;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(Buttonlantern, 5);
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
