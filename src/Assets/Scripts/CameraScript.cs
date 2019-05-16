﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	Transform player;
    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform.Find("Head");
	}

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }
}
