using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesScript : MonoBehaviour
{
    public enum ATTRIBUTES
    {
        HEALTH,
        XP,
        DEFENSE,
        SPEED,
        LEVEL
    }

    public int MAX_HEALTH;

    private Dictionary<ATTRIBUTES, int> attributes;

    void Start()
    {
        attributes = new Dictionary<ATTRIBUTES, int>
        {
            { ATTRIBUTES.HEALTH, MAX_HEALTH },
            { ATTRIBUTES.XP, 0 },
            { ATTRIBUTES.SPEED, 0 },
            { ATTRIBUTES.DEFENSE, 0 },
            { ATTRIBUTES.LEVEL, 1 }
        };
    }

    public void Increase(ATTRIBUTES attr, int toIncrease)
    {
        if(attributes.ContainsKey(attr))
            attributes[attr] += toIncrease;
    }

    public void Decrease(ATTRIBUTES attr, int toDecrease)
    {
        if (attributes.ContainsKey(attr))
            attributes[attr] -= toDecrease;
    }

    public int GetValue(ATTRIBUTES attr)
    {
        int outVal = -1;

        if(attributes == null)
        {
            return 0;
        }

        try
        {
            outVal = attributes[attr];
        }
        catch(KeyNotFoundException)
        {
            Debug.LogError("Key: " + attr + " isn't found on object ");
        }

        return outVal;
    }

    public void SetHealthMax()
    {
        attributes[ATTRIBUTES.HEALTH] = MAX_HEALTH;
    }

    private void Update()
    {
        if(attributes.ContainsKey(ATTRIBUTES.HEALTH) && attributes[ATTRIBUTES.HEALTH] <= 0)
        {
            transform.Find("Head").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
