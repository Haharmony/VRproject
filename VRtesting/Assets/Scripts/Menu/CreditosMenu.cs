using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosMenu : MonoBehaviour
{

    [SerializeField]
    GameObject Creditos, mainMenuPanel;


    public void Back()
    {
        mainMenuPanel.SetActive(true);
        Creditos.SetActive(false);
    }
}
