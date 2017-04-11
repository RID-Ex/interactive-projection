using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UniRx;
using System;

public class PlayerEmitter : NetworkBehaviour {

	public GameObject explosionPrefab;
	public GameObject fireflyPrefab;

	Camera camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			var pos = camera.ScreenToViewportPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
			CmdFire (pos.x, pos.y);
		}
	}

	[Command]
	public void CmdFire(float x, float y) {
		var pos = camera.ViewportToWorldPoint (new Vector3 (x, y, -10));
		pos.z = 0;

		// firefly
		var fireflyPos = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 10));
//		fireflyPos.x = pos.x;
		var firefly = Instantiate(fireflyPrefab, fireflyPos, Quaternion.identity);
		var fireflyRigidBody = firefly.GetComponent<Rigidbody2D> ();
		var d = pos - firefly.transform.position;
		fireflyRigidBody.velocity = d * 0.3F;

		Observable.Timer (TimeSpan.FromSeconds (3.3)).Subscribe (_ => {
			var explosion = Instantiate (explosionPrefab, pos, Quaternion.identity);
			Handheld.Vibrate();
			Destroy (explosion, 3);
		});

		Destroy (firefly, 3);
	}
}
