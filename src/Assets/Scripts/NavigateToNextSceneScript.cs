﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateToNextSceneScript : MonoBehaviour
{
    public GameObject objectiveManager;
    private ObjectivesScript eRS;
	public int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        eRS = objectiveManager.GetComponent<ObjectivesScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsPlayerEntity(Transform tester)
    {
        bool returns = false;

        while (tester != null)
        {
            if (tester.CompareTag("MainPlayer"))
            {
                returns = true;
                break;
            }
            tester = tester.parent;
        }
        return returns;
    }


    void OnCollisionEnter(Collision collision)
	{
		if(IsPlayerEntity(collision.transform) && eRS.enemiesRemaining <= 0)
		{
			SceneManager.LoadScene(nextLevel);
		}
	}
}
