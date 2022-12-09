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
        MenuOver.SetActive(true);
    }

    public void RestardLevel()
    {
        //Para resetear el nivel
        SceneManager.LoadScene(5);
    }

}
