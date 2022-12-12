using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRetry : MonoBehaviour
{
    // Start is called before the first frame update
    public void RetryMenu()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(4, LoadSceneMode.Additive);
  
       
    }
    public void Nvl1()
    {
        SceneManager.LoadScene(8);
        SceneManager.LoadScene(7, LoadSceneMode.Additive);
    }

    public void Nvl2()
    {
        SceneManager.LoadScene(9);
        SceneManager.LoadScene(10, LoadSceneMode.Additive);
    }

    public void NvlInfinity()
    {
        SceneManager.LoadScene(11);
        SceneManager.LoadScene(12, LoadSceneMode.Additive);
    }

}
 