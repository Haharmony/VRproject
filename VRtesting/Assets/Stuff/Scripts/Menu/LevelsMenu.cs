using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenuPanel;
    [SerializeField]
    GameObject LevelsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void Back()
    {
        MainMenuPanel.SetActive(true);
        LevelsPanel.SetActive(false);
    }
}
