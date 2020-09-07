using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOPrefabsMove : MonoBehaviour
{
    public float speed;

    private SceneBehaviour sceneBehaviour;


    private void Start()
    {
        sceneBehaviour = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SceneBehaviour>();
    }

    private void Update()
    {
        if (sceneBehaviour.isLevel_0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -2, -9),speed * Time.deltaTime);
        }
        else if (sceneBehaviour.isLevel_1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -4, -9),speed * Time.deltaTime);
        }
    }
}
