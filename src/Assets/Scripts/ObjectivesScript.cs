using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesScript : MonoBehaviour
{
	public int enemiesRemaining;
	public GameObject currentObjective;
	public GameObject nextRoom;
    // Start is called before the first frame update
    void Start()
    {

    }

	GameObject findClosestEnemy()
	{
		GameObject outVal = null;
		float outValDist = float.MaxValue;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach (GameObject enemy in enemies)
		{
			float delta = Vector3.Distance(Camera.main.transform.position, enemy.transform.position);
			bool isAlive = enemy.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0;
			if (delta < outValDist && isAlive)
			{
				outVal = enemy;
				outValDist = delta;
			}
		}

		return outVal;
	}

	int CalculateEnemiesRemaining()
	{
		int count = 0;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemies)
		{
			if(enemy.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
			{
				count++;
			}
		}
		return count;
	}

    // Update is called once per frame
    void Update()
    {
		enemiesRemaining = CalculateEnemiesRemaining();
		if(enemiesRemaining > 0)
		{
			transform.Find("Text").gameObject.GetComponent<Text>().text = "Enemies Remaining: " + enemiesRemaining;
			currentObjective = findClosestEnemy();
		}
		else
		{
			transform.Find("Text").gameObject.GetComponent<Text>().text = "Objectives Complete";
			currentObjective = nextRoom;
		}
	}
}
