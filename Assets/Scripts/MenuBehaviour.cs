using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject loadLevelMenu_0;
    public GameObject loadLevelMenu_1;
    
    private bool inSettings;
    private bool inSelectLevel;
    private bool levels_0;
    private bool levels_1;
    private bool levels_2;
    private Player playerClass;
    private SceneBehaviour sceneBehaviour;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        print(PlayerPrefs.GetInt("currLevel"));
        print(PlayerPrefs.GetInt("currStage"));
        inSettings = false;
        inSelectLevel = false;
        levels_0 = true;
        levels_1 = false;
        levels_2 = false;
    }

    public void PlayClickButton()
    {
        if (!inSelectLevel)
        {
            levels_0 = true;
            levels_1 = false;
            inSelectLevel = true;
            mainMenu.gameObject.SetActive(false);
            loadLevelMenu_0.gameObject.SetActive(true);
            UpdateButtonsOfLevels();
        }
        else
        {
            inSelectLevel = false;
            loadLevelMenu_0.gameObject.SetActive(false);
            loadLevelMenu_1.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }

    public void NextClickButton()
    {
        if (inSelectLevel)
        {
            if (loadLevelMenu_0.gameObject.activeSelf)
            {
                levels_0 = false;
                levels_1 = true;
                loadLevelMenu_0.gameObject.SetActive(false);
                loadLevelMenu_1.gameObject.SetActive(true);
                UpdateButtonsOfLevels();
            }
        }
    }

    public void NamberLevelClickButton()
    {
        string currLevelString = EventSystem.current.currentSelectedGameObject.name.Remove(0,
            EventSystem.current.currentSelectedGameObject.name.Length - 1);;
        
        if (levels_0)
        {
            PlayerPrefs.SetInt("currStage", 0);

        }
        else if (levels_1)
        {
            PlayerPrefs.SetInt("currStage", 1);
            
        }

        PlayerPrefs.SetInt("currLevel", int.Parse(currLevelString));
        
        SceneManager.LoadScene(1);
    }

    private void UpdateButtonsOfLevels()
    {
        if (levels_0)
        {
            for (int i = 0; i < loadLevelMenu_0.transform.childCount - 3; i++)
            {
                if (i <= PlayerPrefs.GetInt("lastLevelCompleted"))
                {
                    loadLevelMenu_0.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    loadLevelMenu_0.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
        else if(levels_1)
        {
            for (int i = 10; i < loadLevelMenu_1.transform.childCount + 7; i++)
            {
                if (i <= PlayerPrefs.GetInt("lastLevelCompleted"))
                {
                    loadLevelMenu_1.transform.GetChild(i % 10).gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    loadLevelMenu_1.transform.GetChild(i % 10).gameObject.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
    
    public void HardModeClickButton()
    {
        
    }

    public void SettingsClickButton()
    {
        if (!inSettings)
        {
            inSettings = true;
            mainMenu.gameObject.SetActive(false);
            settingsMenu.gameObject.SetActive(true);
        }
        else
        {
            inSettings = false;
            settingsMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
            
        }
    }
    
    
}
