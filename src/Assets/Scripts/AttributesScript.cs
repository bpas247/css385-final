using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesScript : MonoBehaviour
{
    public enum ATTRIBUTES
    {
        HEALTH,
        XP,
        DAMAGE
    }

    private Dictionary<ATTRIBUTES, int> attributes;

    void Start()
    {
        attributes = new Dictionary<ATTRIBUTES, int>();
        attributes.Add(ATTRIBUTES.HEALTH, 300);
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

    private void Update()
    {
        if(attributes.ContainsKey(ATTRIBUTES.HEALTH) && attributes[ATTRIBUTES.HEALTH] <= 0)
        {
            transform.Find("Head").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
