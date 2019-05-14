using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float movementSpeed;
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
		myBody.transform.position = Vector3.MoveTowards(myBody.transform.position, player.position, movementSpeed * Time.deltaTime);
	}
}
