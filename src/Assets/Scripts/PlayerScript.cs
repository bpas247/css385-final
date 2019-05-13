using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public float movementSpeed, rotateSpeed;

	private void MoveEffect(KeyCode code, Vector3 movement)
	{
		if (Input.GetKey(code))
		{
			transform.Find("Pelvis").GetComponent<Rigidbody>().AddForce(movement * movementSpeed, ForceMode.Impulse);
			transform.Find("Body").GetComponent<Rigidbody>().AddForce(movement * movementSpeed, ForceMode.Impulse);

		}
	}

	// Update is called once per frame
	void Update()
    {
		MoveEffect(KeyCode.W, Vector3.forward);
		MoveEffect(KeyCode.S, Vector3.back);
		MoveEffect(KeyCode.A, Vector3.left);
		MoveEffect(KeyCode.D, Vector3.right);

		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Find("Body").Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Find("Body").Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		//Plane plane = new Plane(Vector3.up, Vector3.zero);
		//float distance;
		//if (plane.Raycast(ray, out distance))
		//{
		//	Vector3 target = ray.GetPoint(distance);
		//	Vector3 direction = target - transform.position;
		//	float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
		//	//transform.rotation = Quaternion.Euler(0, rotation, 0);
		//	//transform.Find("Head").rotation = Quaternion.Euler(0, rotation, 0);
		//	//transform.Find("Pelvis").rotation = Quaternion.Euler(0, rotation, 0);
		//}
	}
}
