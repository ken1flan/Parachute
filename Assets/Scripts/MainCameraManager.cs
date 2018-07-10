using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraManager : MonoBehaviour {
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		var newPositionY = player.transform.position.y - 2;
		transform.position = new Vector3 (transform.position.x, newPositionY, transform.position.z);
	}
}
