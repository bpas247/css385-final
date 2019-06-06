using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHelpScript : MonoBehaviour
{
	public bool show = false;
	private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
		canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.H))
		{
			show = !show;
		}
		canvas.enabled = show;

		Time.timeScale = show ? 0 : 1;
    }
}
