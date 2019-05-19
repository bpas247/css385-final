using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float movementSpeed, rotateSpeed;
    public Transform player;
    private Transform[] myMovingParts;
	// Start is called before the first frame update
	void Start()
    {
        myMovingParts = new[]{ transform.Find("Body"), transform.Find("Body").Find("Right Arm")};

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
    }
}
