using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject MainMenuPanel;
    [SerializeField]
    GameObject LevelsPanel;
    [SerializeField]
    GameObject ExtraPanel;
    [SerializeField]
    GameObject CreditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelsButton()
    {
        MainMenuPanel.SetActive(false);
    }
}
