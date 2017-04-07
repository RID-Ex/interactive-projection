using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerEmitter : NetworkBehaviour {

	public GameObject particlePrefab;

	Camera camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			CmdFire (Input.mousePosition.x, Input.mousePosition.y);
		}
	}

	[Command]
	public void CmdFire(float x, float y) {
		var pos = camera.ScreenToWorldPoint (new Vector3 (x, y, -10));
		pos.z = 0;
		var particle = Instantiate (particlePrefab, pos, Quaternion.identity);
		Destroy (particle, 3);
	}
}
