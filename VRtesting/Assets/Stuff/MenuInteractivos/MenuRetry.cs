using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRetry : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryMenu()
    {
        SceneManager.LoadScene(1);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
  
       
    }
    public void Nvl1()
    {
        SceneManager.LoadScene(3);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
    }

    public void Nvl2()
    {
        SceneManager.LoadScene(5);
        SceneManager.LoadScene(6, LoadSceneMode.Additive);
    }

    public void NvlInfinity()
    {
        SceneManager.LoadScene(7);
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
    }
    public void Bye()
    {
        Application.Quit();
        Debug.Log("sali");
    }

}
 