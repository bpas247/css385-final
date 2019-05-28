using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventroyScript : MonoBehaviour
{
    public GameObject inventory;

    private int allSlots;
    private GameObject[] slots;

    public GameObject slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        allSlots = 8;
        slots = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;

            if(slots[i].GetComponent<Slot>().item == null)
            {
                slots[i].GetComponent<Slot>().empty = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
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

    void AddItem(GameObject itemPickedUp, int weaponDamage, double weaponSpeed, double weaponRange, Texture2D icon)
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
}
