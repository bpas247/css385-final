﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<AccessPlayerScript>().player;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().fillAmount = ( player.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) / (float)(player.GetComponent<AttributesScript>().MAX_HEALTH));
    }
}
