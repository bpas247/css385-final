using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonNavigationScript : MonoBehaviour
{
	public int sceneToLoad;
	private Button btn;
	void Start()
	{
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(NavigateToScene);
	}

	void NavigateToScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
