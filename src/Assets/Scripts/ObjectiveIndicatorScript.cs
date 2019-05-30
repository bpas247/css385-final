using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveIndicatorScript : MonoBehaviour
{
	RectTransform rectT;
	// Start is called before the first frame update
	void Start()
    {
		rectT = GetComponent<RectTransform>();

	}


    // Update is called once per frame
    void Update()
    {
		GameObject curObjective = GetComponentInParent<ObjectivesScript>().currentObjective;

		if(curObjective)
		{
			Vector3 targ;
			if (curObjective.CompareTag("Enemy"))
			{
				targ = curObjective.transform.Find("Head").transform.position;
			}
			else
			{
				targ = curObjective.transform.position;
			}
			Vector3 objectPos = Camera.main.transform.position;

			float deltaX = targ.x - objectPos.x;
			float deltaZ = targ.z - objectPos.z;

			// Use Trig to get my Angle IN RANGE -180 to 180
			float angle = Mathf.Atan2(deltaX, deltaZ) * Mathf.Rad2Deg;

			rectT.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));

		}
	}
}
