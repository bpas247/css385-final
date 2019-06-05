using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveEnemyRemainingScript : ObjectiveScript
{
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
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
            {
                count++;
            }
        }
        return count;
    }

    // Update is called once per frame
    void Update()
    {
        int enemiesRemaining = CalculateEnemiesRemaining();
        if (enemiesRemaining > 0)
        {
            OutputToUser = "Enemies Remaining: " + enemiesRemaining;
            CurrentObjective = findClosestEnemy();
        }
        else
        {
            CurrentObjective = null; // Signifying that all of the objectives are complete
        }
    }

}
