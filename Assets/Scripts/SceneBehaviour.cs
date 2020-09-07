using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneBehaviour : MonoBehaviour
{
    [Header("UI")]
    public Text currLevelText;
    public Text currMainLevelText;
    public Button buttonForPlay;
    
    public static int levelComplete;
    public static int levelMainCurr;

    [Header("Test mode")]
    public bool isTestMode;
    
    [HideInInspector]public bool isLevel_0;
    [HideInInspector]public bool isLevel_1;
    [HideInInspector]public bool isLevel_2;
    [HideInInspector]public bool isStoped;
    
    [HideInInspector]public int levelCount;
    [HideInInspector]public int lastLevelCompleted;
    
    [Header("Links")]
    public GameObject wallObjects_0;
    public GameObject playerObjects_0;
    public GameObject wallObjects_1;
    public GameObject playerObjects_1;

    private Player playerClass_0;
    private Player playerClass_1;
    private int levelCountText;

    private void Start()
    {
        playerClass_0 = playerObjects_0.GetComponent<Player>();
        playerClass_1 = playerObjects_1.GetComponent<Player>();

        switch (PlayerPrefs.GetInt("currStage"))
        {
            case 0:
                isLevel_0 = true;
                isLevel_1 = false;
                isLevel_2 = false;
                levelMainCurr = 0;
                levelCountText = PlayerPrefs.GetInt("currLevel");
                levelCount = PlayerPrefs.GetInt("currLevel");
                lastLevelCompleted =  PlayerPrefs.GetInt("currLevel");
                SelectLevel_0();
                break;
            
            case 1:
                isLevel_0 = false;
                isLevel_1 = true;
                isLevel_2 = false;
                levelMainCurr = 1;
                levelCountText = PlayerPrefs.GetInt("currLevel") + 10;
                levelCount = PlayerPrefs.GetInt("currLevel") % 10;
                lastLevelCompleted = PlayerPrefs.GetInt("currLevel") % 10;
                SelectLevel_1();
                break;
            
        }
        
        isStoped = false;
        levelComplete = 0;
    }

    private void Update()
    {
        if (levelComplete == 1)
        {
            levelComplete = 0;
            Win();
            
        }

        if (levelComplete == -1)
        {
            buttonForPlay.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
            isStoped = true;

            Lose();
            levelComplete = 0;
        }

        switch (levelMainCurr)
        {
            case 0:
                isLevel_0 = true;
                isLevel_1 = false;
                break;
            
            case 1:
                isLevel_0 = false;
                isLevel_1 = true;
                break;
        }
        
        if (levelCount > (wallObjects_0.transform.childCount - 1) && isLevel_0)
        {
            levelMainCurr = 1;
            HideLastLevel(wallObjects_0, playerObjects_0);
            levelCount = 0;
            SelectLevel_1();
        }

        currLevelText.text = " " + (levelCountText + 1) + " / " + (wallObjects_0.transform.childCount + wallObjects_1.transform.childCount);
        currMainLevelText.text = " " + (levelMainCurr + 1) + " / 2";

        if (PlayerPrefs.GetInt("lastLevelCompleted") < lastLevelCompleted)
        {
            PlayerPrefs.SetInt("lastLevelCompleted", lastLevelCompleted);
            print(PlayerPrefs.GetInt("lastLevelCompleted"));
        }
        
        //print(isLevel_1 + " = is level 1");
        PlayerPrefs.SetInt("lastStageCompleted", levelMainCurr);
    }

    private void Win()
    {
        levelCount++;
        levelCountText++;
        if (isLevel_0)
        {
            SelectLevel_0(); 
            playerClass_0.speed = playerClass_0.maxSpeed;
            lastLevelCompleted = levelCount;
        }
        else if (isLevel_1)
        {
            SelectLevel_1();
            playerClass_1.speed = playerClass_1.maxSpeed;
            lastLevelCompleted = levelCount + 10;
        }

        print("lastLevelCompleted = " + lastLevelCompleted);
        print("levelCount = " + levelCount);
    }

    private void Lose()
    {
        levelCount = lastLevelCompleted % 10;
        
        if (isLevel_0)
        {
            SelectLevel_0();
            playerClass_0.speed = playerClass_0.maxSpeed;
        }
        else if (isLevel_1)
        {
            SelectLevel_1();
            playerClass_1.speed = playerClass_1.maxSpeed;
        }
        
        print("lastLevelCompleted = " + lastLevelCompleted);
        print("levelCount = " + levelCount);
    }

    private void SelectLevel_0()
    {
        insideSelectLevel(wallObjects_0, playerObjects_0);
    }

    private void SelectLevel_1()
    {
        insideSelectLevel(wallObjects_1, playerObjects_1);
    }

    private void HideLastLevel(GameObject wallGOs, GameObject playerGOs)
    {
        Transform lastWall = wallGOs.transform.GetChild(wallGOs.transform.childCount - 1);
        lastWall.gameObject.SetActive(false);
        lastWall.position = wallGOs.transform.position;
        Transform lastPlayer = playerGOs.transform.GetChild(playerGOs.transform.childCount - 1);
        lastPlayer.gameObject.SetActive(false);
    }

    private void insideSelectLevel(GameObject wallGOs, GameObject playerGOs)
    {
        if (isLevel_0)
        {
            int i = 0;
            int j = 0;
            
            foreach (Transform wall in wallGOs.transform)
            {
                if (i == levelCount)
                {
                    wall.gameObject.SetActive(true);
                }
                else
                {
                    wall.gameObject.SetActive(false);
                    wall.position = wallGOs.transform.position;
                }
                i++;
            }

            foreach (Transform player in playerGOs.transform)
            {
                if (j == levelCount)
                {
                    player.gameObject.SetActive(true);
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                j++;
            }
        }
        
        if (isLevel_1)
        {
            int i = 0;
            int j = 0;
            
            foreach (Transform wall in wallGOs.transform)
            {
                if (i == levelCount)
                {
                    wall.gameObject.SetActive(true);
                }
                else
                {
                    wall.gameObject.SetActive(false);
                    wall.position = wallGOs.transform.position;
                }
                i++;
            }

            foreach (Transform player in playerGOs.transform)
            {
                if (j == levelCount)
                {
                    player.gameObject.SetActive(true);
                }
                else
                {
                    player.gameObject.SetActive(false);
                }
                j++;
            }
        }
    }
    
}
