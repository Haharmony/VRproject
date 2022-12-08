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
}
