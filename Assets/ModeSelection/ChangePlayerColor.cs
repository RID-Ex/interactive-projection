using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangePlayerColor : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void OnStartLocalPlayer() {
		var meshes = GetComponentsInChildren<MeshRenderer> ();

		foreach (MeshRenderer mesh in meshes) {
			mesh.material.color = Color.red;
		}
	}
}
