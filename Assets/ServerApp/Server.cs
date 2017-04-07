using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Server : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetupServer ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetupServer() {
		Debug.Log ("test");
		NetworkServer.Listen ("127.0.0.1", 2000);
		NetworkServer.RegisterHandler (MsgType.Connect, OnConnected);
		NetworkServer.RegisterHandler (888, OnReceive);
	}

	public void OnConnected(NetworkMessage netMsg) {
		Debug.Log ("Connected to client");
	}

	public void OnReceive(NetworkMessage netMsg) {
		Debug.Log ("Receive");
		var recvMsg = netMsg.ReadMessage<StringMessage> ();
		Debug.Log (recvMsg.value);
	}
}
