using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelectionManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickServer() {
		SceneManager.LoadScene ("ServerScene");
	}

	public void OnClickClient() {
		SceneManager.LoadScene ("ClientScene");
	}
}
