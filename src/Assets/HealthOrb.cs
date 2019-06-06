﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("MainPlayer"))
        {
            GameObject player = GameObject.FindWithTag("MainPlayer");
            AttributesScript att = player.GetComponent<AttributesScript>();

            if(att.GetValue(AttributesScript.ATTRIBUTES.HEALTH) <= (att.MAX_HEALTH - 250))
            {
                att.Increase(AttributesScript.ATTRIBUTES.HEALTH, 250);
            }
            else
            {
                att.SetHealthMax();
            }

            Destroy(gameObject);
        }
    }
}
