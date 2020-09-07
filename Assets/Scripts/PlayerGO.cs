using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGO : MonoBehaviour
{

    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            SceneBehaviour.levelComplete = -1;
        }

        if (other.tag == "Goal")
        {
            SceneBehaviour.levelComplete = 1;
        }
    }
}
