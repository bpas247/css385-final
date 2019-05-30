using System.Collections;
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
                attr.Decrease(AttributesScript.ATTRIBUTES.HEALTH, equippedWeapon.weaponDamage);

                if (attr.GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * 400, ForceMode.Impulse);
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
        GameObject.FindWithTag("MainPlayer").GetComponent<PlayerScript>().rotateSpeed = 500 * (float)(equippedWeapon.weaponSpeed);

    }
}
