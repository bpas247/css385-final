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
        attributes = new Dictionary<ATTRIBUTES, int>();
        attributes.Add(ATTRIBUTES.HEALTH, MAX_HEALTH);
        attributes.Add(ATTRIBUTES.XP, 0);
        attributes.Add(ATTRIBUTES.SPEED, 0);
        attributes.Add(ATTRIBUTES.DEFENSE, 0);
        attributes.Add(ATTRIBUTES.LEVEL, 1);
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
        return attributes[attr];
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
