using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH));
        GetComponent<Image>().fillAmount = ( player.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) / 3.0f);
    }
}
