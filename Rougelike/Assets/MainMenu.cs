// Written by Dom Uzuegbu
// 11/23/22
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    
    public void EndGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
