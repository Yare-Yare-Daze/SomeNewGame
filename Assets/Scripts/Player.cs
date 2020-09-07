using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject camera;
    
    public float speed;
    public float maxSpeed;

    private SceneBehaviour sceneBehaviour;

    private void Start()
    {
        sceneBehaviour = camera.gameObject.GetComponent<SceneBehaviour>();
        maxSpeed = speed;
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!sceneBehaviour.isTestMode)
        {
            transform.Rotate(0, 0, speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.collider.tag);
    }

    public void TapToScreen()
    {
        if (sceneBehaviour.isStoped)
        {
            sceneBehaviour.buttonForPlay.transform.GetChild(0).gameObject.SetActive(false);
            if (sceneBehaviour.isLevel_0)
            {
                sceneBehaviour.wallObjects_0.transform.GetChild(sceneBehaviour.levelCount).transform.position 
                    = sceneBehaviour.wallObjects_0.transform.position;
            }
            else if (sceneBehaviour.isLevel_1)
            {
                sceneBehaviour.wallObjects_1.transform.GetChild(sceneBehaviour.levelCount).transform.position 
                    = sceneBehaviour.wallObjects_1.transform.position;
            }
            Time.timeScale = 1;
            sceneBehaviour.isStoped = false;
        }
        else if (speed != 0)
        {
            speed = 0;
        }
        else if (speed == 0)
        {
            speed = maxSpeed;
        }
    }
}
