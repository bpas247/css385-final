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

	private void RotateEffect(KeyCode code, Vector3 movement)
	{
		if (Input.GetKey(code))
		{
			transform.Find("Pelvis").Rotate(movement * rotateSpeed * Time.deltaTime);
			transform.Find("Body").Rotate(movement * rotateSpeed * Time.deltaTime);
		}
	}

	// Update is called once per frame
	void Update()
    {
        if(GetComponent<AttributesScript>().GetValue(AttributesScript.ATTRIBUTES.HEALTH) > 0)
        {
            MoveEffect(KeyCode.W, Vector3.forward);
            MoveEffect(KeyCode.S, Vector3.back);
            MoveEffect(KeyCode.A, Vector3.left);
            MoveEffect(KeyCode.D, Vector3.right);

            RotateEffect(KeyCode.LeftArrow, -Vector3.up);
            RotateEffect(KeyCode.RightArrow, Vector3.up);
        }
    }
}
