﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
	public string taggedToKill;
    ItemDropScript equippedWeapon;
    // Start is called before the first frame update
    void Start()
    {
        equippedWeapon = new ItemDropScript();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	bool isEntityToKill(Transform tester)
	{
		bool returns = false;

		while(tester != null)
		{
            if (tester.CompareTag(taggedToKill))
			{
				returns = true;
				break;
			}
			tester = tester.parent;
		}
		return returns;
	}

	private void OnCollisionEnter(Collision collision)
	{
        AttributesScript myAttr = transform.GetComponentInParent<AttributesScript>();
        if (myAttr.GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
		{
            if(!collision.gameObject.CompareTag("Weapon") && isEntityToKill(collision.transform))
            {
                AttributesScript attr = collision.transform.GetComponentInParent<AttributesScript>();
                attr.Decrease(AttributesScript.ATTRIBUTES.HEALTH, (equippedWeapon.weaponDamage - (int)(equippedWeapon.weaponDamage * CalculateDefense(attr.GetValue(AttributesScript.ATTRIBUTES.DEFENSE)))));

                if (attr.GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
                {
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * 400, ForceMode.Impulse);
                }
                else
                {
                    if(collision.transform.GetComponentInParent<EnemyScript>().xpRewarded == false)
                    {
                        GameObject.Find("GameSystem").GetComponent<AccessPlayerScript>().player.GetComponent< AttributesScript>().Increase(AttributesScript.ATTRIBUTES.XP, 50);
                        collision.transform.GetComponentInParent<EnemyScript>().xpRewarded = true;
                    }
                    
                }   
            }

            if(gameObject.tag.Equals("MainPlayer") && collision.gameObject.CompareTag("Weapon"))
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * 500, ForceMode.Impulse);
            }
        }
	}

    public void equipItem(GameObject item)
    {
        equippedWeapon = item.GetComponent<ItemDropScript>();
        GameObject.Find("GameSystem").GetComponent<AccessPlayerScript>().player.GetComponent<PlayerScript>().rotateSpeed = 500 * (float)(equippedWeapon.weaponSpeed);

    }

    private double CalculateDefense(int defenseRating)
    {
        double percent = 1.0;
        double def = 0.0;
        while(defenseRating > 0)
        {
            def += percent / 10;
            percent -= percent / 10;
            defenseRating--;
        }

        return def;
    }
}
