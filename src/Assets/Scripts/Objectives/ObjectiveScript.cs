using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectiveScript : MonoBehaviour
{
    public string OutputToUser { get; protected set; }

    public GameObject CurrentObjective { get; protected set; }
}
