using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [Header("References")]
    public GameObject mainUI;
    public GameObject settingsUI;
    public GameObject creditsPanel;


    public Button settingsButton;
    public GameObject backFromCredits;

    private void Start()
    {
        backFromCredits.SetActive(false);
        creditsPanel.SetActive(false);
    }
    public void SettingsMenu()
    {
        mainUI.SetActive(false);
    }

    public void CreditsPanel()
    {
        creditsPanel.SetActive(true);
        backFromCredits.SetActive(true);
    }

    public void HideCredPanel()
    {
        creditsPanel.SetActive(false);
        backFromCredits.SetActive(false);
    }



    

    
}
