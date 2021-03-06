﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventroyScript : MonoBehaviour
{
    public GameObject inventory;
    GameObject player;

    private int allSlots;
    private GameObject[] slots;
    private int currentEquip;
    public GameObject slotHolder;

    public int skillPoints;
    public int HP;
    public int Defense;
    public int Speed;
    public int Level;

    Text HPText;
    Text DefenseText;
    Text SpeedText;
    Text LevelText;
    Text SkillPointsText;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<AccessPlayerScript>().player;
        currentEquip = -1;
        allSlots = 8;
        slots = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

            if(slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
                slots[i].GetComponent<Slot>().slotNum = i;
                slots[i].GetComponent<Slot>().equipped = false;
            }

        }

        player = GetComponentInParent<AccessPlayerScript>().player;
        AttributesScript att = player.GetComponent<AttributesScript>();

        skillPoints = 0;
        HP = att.MAX_HEALTH;
        Defense = att.GetValue(AttributesScript.ATTRIBUTES.DEFENSE);
        Speed = att.GetValue(AttributesScript.ATTRIBUTES.SPEED);
        Level = att.GetValue(AttributesScript.ATTRIBUTES.LEVEL);
        HPText = inventory.transform.Find("XPSystem/HP").GetComponent<Text>();
        DefenseText = inventory.transform.Find("XPSystem/Defense").GetComponent<Text>();
        SpeedText = inventory.transform.Find("XPSystem/Speed").GetComponent<Text>();
        LevelText = inventory.transform.Find("XPSystem/Level").GetComponent<Text>();
        SkillPointsText = inventory.transform.Find("XPSystem/Skill Points").GetComponent<Text>();

        HPText.text = "HP: " + HP;
        DefenseText.text = "Defense: " + Defense;
        SpeedText.text = "Speed: " + Speed;
        LevelText.text = "Level: " + Level;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }

        if(skillPoints > 0)
        {
            inventory.transform.Find("XPSystem/HPButton").gameObject.SetActive(true);
            inventory.transform.Find("XPSystem/DefenseButton").gameObject.SetActive(true);
            inventory.transform.Find("XPSystem/SpeedButton").gameObject.SetActive(true);
        }
        else
        {
            inventory.transform.Find("XPSystem/HPButton").gameObject.SetActive(false);
            inventory.transform.Find("XPSystem/DefenseButton").gameObject.SetActive(false);
            inventory.transform.Find("XPSystem/SpeedButton").gameObject.SetActive(false);
        }
    }

    public void itemClicked(GameObject other)
    {
        if(other.tag == "Weapon")
        {
            GameObject itemPickedUp = other;
            ItemDropScript item = itemPickedUp.GetComponent<ItemDropScript>();

            AddItem(itemPickedUp, item.weaponDamage, item.weaponSpeed, item.weaponRange, item.icon);
        }
    }

    void AddItem(GameObject itemPickedUp, int weaponDamage, double weaponSpeed, double weaponRange, Sprite icon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if(slots[i].GetComponent<Slot>().empty)
            {
                itemPickedUp.GetComponent<ItemDropScript>().pickedUp = true;
              
                slots[i].GetComponent<Slot>().item = itemPickedUp;
                slots[i].GetComponent<Slot>().icon = icon;
                slots[i].GetComponent<Slot>().weaponDamage = weaponDamage;
                slots[i].GetComponent<Slot>().weaponSpeed = weaponSpeed;
                slots[i].GetComponent<Slot>().weaponRange = weaponRange;

                itemPickedUp.transform.parent = slots[i].transform;
                itemPickedUp.SetActive(false);
                //Destroy(itemPickedUp);

                slots[i].GetComponent<Slot>().UpdateSlot();
                slots[i].GetComponent<Slot>().empty = false;
                break;
            }
        }
    }

    public void ItemEquipped(int slotNumber)
    {
        slots[slotNumber].GetComponent<Slot>().gameObject.GetComponent<Image>().color = new Color32(124, 255, 81, 255);
        slots[slotNumber].GetComponent<Slot>().equipped = true;

        if (currentEquip != -1)
        {
            slots[currentEquip].GetComponent<Slot>().gameObject.GetComponent<Image>().color = new Color32(255, 204, 81, 255);
            slots[currentEquip].GetComponent<Slot>().equipped = false;
        }

        currentEquip = slotNumber;

        //GameObject mainPlayer = GameObject.FindWithTag("MainPlayer");
        PlayerScript mainPlayer = player.GetComponent<PlayerScript>();

        GameObject itemEquip = slots[slotNumber].GetComponent<Slot>().item;
        ItemDropScript item = itemEquip.GetComponent<ItemDropScript>();

        mainPlayer.transform.Find("Body").gameObject.transform.Find("Right Arm").gameObject.transform.Find("Sword Long").gameObject.GetComponent<SwordScript>().
            equipItem(itemEquip);

        mainPlayer.rotateSpeed = 500 * (float)(item.weaponSpeed);

        mainPlayer.transform.Find("Body").gameObject.transform.Find("Right Arm").gameObject.transform.Find("Sword Long").gameObject.transform.localScale = new Vector3(500, 500, 100 * (float)item.weaponRange);


    }

    public void LevelHP()
    {
        skillPoints--;
        HP += 100;
        HPText.text = "HP: " + HP;
        SkillPointsText.text = "Skill Points: " + skillPoints;
        player.GetComponent<AttributesScript>().MAX_HEALTH += 100;
    }

    public void LevelDefense()
    {
        skillPoints--;
        Defense++;
        DefenseText.text = "Defense: " + Defense;
        SkillPointsText.text = "Skill Points: " + skillPoints;
        player.GetComponent<AttributesScript>().Increase(AttributesScript.ATTRIBUTES.DEFENSE, 1);
    }

    public void LevelSpeed()
    {
        skillPoints--;
        Speed++;
        SpeedText.text = "Speed: " + Speed;
        SkillPointsText.text = "Skill Points: " + skillPoints;
        player.GetComponent<AttributesScript>().Increase(AttributesScript.ATTRIBUTES.SPEED, 1);
    }

    public void UpdateLevel()
    {
        Level++;
        LevelText.text = "Level: " + Level;
        player.GetComponent<AttributesScript>().Increase(AttributesScript.ATTRIBUTES.LEVEL, 1);
    }

    public void UpdateSkillPoints()
    {
        skillPoints++;
        SkillPointsText.text = "Skill Points: " + skillPoints;
    }
}
