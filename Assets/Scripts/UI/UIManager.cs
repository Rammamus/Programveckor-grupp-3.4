using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public GameObject settingsPanel;
    public GameObject settingsButton;
    public GameObject backButton;

    public bool isSettingsActive;

    private void Start()
    {
        isSettingsActive = false;
        settingsPanel.SetActive(isSettingsActive);
    }


    private void Update()
    {
        print("hello");
    }
    #region buttons


    public void Back()
    {
        if (isSettingsActive)
        {
            isSettingsActive = false;
            settingsPanel.SetActive(isSettingsActive);
        }

        Time.timeScale = 1;
    }

    #endregion

    public void ActivateSettings()
    {

        isSettingsActive = true;
        settingsPanel.SetActive(isSettingsActive);

        Time.timeScale = 0;

    }
}
