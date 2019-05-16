using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
	public string taggedToKill;
	private GameObject enemy;
	public int enemyHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
		enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag(taggedToKill))
		{
			Debug.Log("Kill " + collision.gameObject.name);
			if(collision.gameObject.CompareTag("Enemy"))
				enemyHealth--;
			if(enemyHealth <= 0)
			{
				Destroy(enemy);
			}
			collision.gameObject.GetComponent<Rigidbody>().AddForce(-collision.GetContact(0).normal * 600, ForceMode.Impulse);
		}
	}
}
