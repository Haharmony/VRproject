using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    public GameObject MenuOver;



    private void OnEnable()
    {
        Player3D.OnPlayerDeath += EnableGameOverMenu;
    }  
    private void OnDisable()
    {
        Player3D.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu()
    {
        //Activar el menu de gameover con el evento de arriba
        MenuOver.SetActive(true);
    }

    public void RestardLevel()
    {
        //Para resetear el nivel
        SceneManager.LoadScene(5);
    }
    public void MainMenuBack()
    {
        //Para resetear el nivel
        SceneManager.LoadScene(3);
    }

}
