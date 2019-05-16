using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float movementSpeed, rotateSpeed;
	public int health;
	public bool isDead = false;
	private Transform player, myBody;
	// Start is called before the first frame update
	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
		if(health <= 0)
		{
			Debug.Log("Death");
			Destroy(gameObject);
		}

		myBody = transform.Find("Body");
		player = GameObject.FindGameObjectWithTag("Player").transform.Find("Body");


		//Vector3 movement = Vector3.MoveTowards(myBody.transform.position, player.position, movementSpeed * Time.deltaTime);
		//myBody.transform.position = movement;
		//transform.Find("Pelvis").position = movement;
		
		//Vector3 direction = Random.value > 0.5f ? Vector3.up : -Vector3.up;
		//transform.Find("Pelvis").Rotate(direction * rotateSpeed * Time.deltaTime);
		//transform.Find("Body").Rotate(direction * rotateSpeed * Time.deltaTime);
	}
}
