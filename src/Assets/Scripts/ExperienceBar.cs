using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
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
        GetComponent<Image>().fillAmount = (player.GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.XP) / 100.0f);

        if(GetComponent<Image>().fillAmount >= 1)
        {
            GameObject.Find("GameSystem/GameManager").GetComponent<InventroyScript>().UpdateLevel();
            GameObject.Find("GameSystem/GameManager").GetComponent<InventroyScript>().UpdateSkillPoints();
            GetComponent<Image>().fillAmount = 0.0f;
            player.GetComponent<AttributesScript>().Decrease(AttributesScript.ATTRIBUTES.XP, 100);
        }
    }
}
