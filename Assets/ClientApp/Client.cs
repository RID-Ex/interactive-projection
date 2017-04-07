using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Client : MonoBehaviour {

	NetworkClient myClient;

	// Use this for initialization
	void Start () {
		SetupClient ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetupClient() {
		myClient = new NetworkClient ();
		myClient.RegisterHandler (MsgType.Connect, OnConnected);
	
		myClient.Connect ("127.0.0.1", 2000);
	}

	public void OnConnected(NetworkMessage netMsg) {
		Debug.Log ("Connected to server");

		var myMsg = new StringMessage ("test");
		myClient.Send (888, myMsg);
	}

	public void OnReceive(NetworkMessage netMsg) {
		Debug.Log (netMsg.ToString ());
	}
}
