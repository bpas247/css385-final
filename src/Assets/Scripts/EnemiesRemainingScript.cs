using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesRemainingScript : MonoBehaviour
{
	public int enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
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
		transform.Find("Text").gameObject.GetComponent<Text>().text = "Enemies Remaining: " + enemiesRemaining; 
	}
}
