using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Button buttonPause;
    
    private bool isPaused;
    
    private void Start()
    {
        isPaused = false;
    }

    public void TapToPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            buttonPause.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (isPaused)
        {
            isPaused = false;
            buttonPause.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        
        
    }
}
