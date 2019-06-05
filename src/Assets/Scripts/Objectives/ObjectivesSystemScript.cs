using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesSystemScript : MonoBehaviour
{
	public GameObject nextRoom;
    public GameObject currentObjective { get; private set; }
    public ObjectiveScript Objective { get; private set; }
    public bool CanProceed { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Objective = GetComponent<ObjectiveScript>();
        CanProceed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Objective.CurrentObjective != null)
        {
            transform.Find("Text").gameObject.GetComponent<Text>().text = Objective.OutputToUser;
            transform.Find("Text").gameObject.GetComponent<Text>().color = Color.red;
            currentObjective = Objective.CurrentObjective;
        }
        else
        {
            transform.Find("Text").gameObject.GetComponent<Text>().text = "Objectives Complete";
            transform.Find("Text").gameObject.GetComponent<Text>().color = Color.green;
            currentObjective = nextRoom;
            CanProceed = true;
        }
	}
}
