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

}
