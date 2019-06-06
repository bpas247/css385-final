using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float movementSpeed, rotateSpeed;
	public GameObject itemToDrop;
    public Transform player;

    private Transform[] myMovingParts;
	private bool hasDroppedItem = false;
    public bool xpRewarded = false;

	// Start is called before the first frame update
	void Start()
    {
        myMovingParts = new[]{ transform.Find("Body"), transform.Find("Body").Find("Right Arm")};
        GetComponent<AttributesScript>().MAX_HEALTH = 500;

    }

    // Update is called once per frame
    void Update()
    {



        if (GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
        {
            foreach(Transform myMovingPart in myMovingParts)
            {
                Vector3 movement = player.position - myMovingPart.position;

                movement = new Vector3(movement.x < 0 ? -1 : 1, movement.y, movement.z < 0 ? -1 : 1);

                myMovingPart.GetComponent<Rigidbody>().AddForce(movement * movementSpeed, ForceMode.Impulse);
            }
        }
		else
		{
			if(!hasDroppedItem)
			{
				Instantiate(itemToDrop, new Vector3(myMovingParts[0].position.x, 5, myMovingParts[0].position.z), Quaternion.identity);
				Destroy(myMovingParts[1].Find("Sword Long").gameObject);
				hasDroppedItem = true;
			}
		}
    }
}
