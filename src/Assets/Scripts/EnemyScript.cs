using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float movementSpeed, rotateSpeed;
	public bool isDead = false;
	private Transform player, myBody;
	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		myBody = transform.Find("Body");
		player = GameObject.FindGameObjectWithTag("Player").transform.Find("Body");

        Vector3 movement = player.position - myBody.position;

        movement = new Vector3(movement.x < 0 ? -1 : 1, movement.y, movement.z < 0 ? -1 : 1);
        
        if(GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) >= 0)
            myBody.GetComponent<Rigidbody>().AddForce(movement * movementSpeed, ForceMode.Impulse);
    }
}
