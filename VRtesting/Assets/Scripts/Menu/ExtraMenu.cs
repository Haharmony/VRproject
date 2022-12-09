using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenuPanel;
    [SerializeField]
    GameObject extraPanel;
    [SerializeField]
    GameObject PersonajePanel;
    [SerializeField]
    GameObject EnemigosPanel;
    [SerializeField]
    GameObject EnemySlow;
    [SerializeField]
    GameObject EnemyMedium;
    [SerializeField]
    GameObject EnemyTank;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        mainMenuPanel.SetActive(true);
        extraPanel.SetActive(false);
    }

    public void Personaje()
    {
        extraPanel.SetActive(false);
        PersonajePanel.SetActive(true);
    }
    public void BackPersonaje()
    {
        extraPanel.SetActive(true);
        PersonajePanel.SetActive(false);
    }
    public void Enemigos()
    {
        extraPanel.SetActive(false);
        EnemigosPanel.SetActive(true);
    }
    public void BackEnemigo()
    {
        extraPanel.SetActive(true);
        EnemigosPanel.SetActive(false);
    }
    public void EnemigoSlowpanle()
    {
        EnemigosPanel.SetActive(false);
        EnemySlow.SetActive(true);
    }
    public void EnemigoMediumpanle()
    {
        EnemigosPanel.SetActive(false);
        EnemyMedium.SetActive(true);
    }
    public void EnemigoTankpanle()
    {
        EnemigosPanel.SetActive(false);
        EnemyTank.SetActive(true);
    }
    public void BackEnemigoSlow()
    {
        EnemigosPanel.SetActive(true);
        EnemySlow.SetActive(false);
    }
    public void BackEnemigoMedium()
    {
        EnemigosPanel.SetActive(true);
        EnemyMedium.SetActive(false);
    }
    public void BackEnemigoTank()
    {
        EnemigosPanel.SetActive(true);
        EnemyTank.SetActive(false);
    }

}
