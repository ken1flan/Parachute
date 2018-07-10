using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {
	private bool useRightFan = false;
	private bool useLeftFan = false;
	private Vector2 fanPower = new Vector2(1.0f, 0);
	private float dragDefault = 1.0f;
	private float dragUsingFan = 1.5f;
	private Text velocityText;
	private Text positionText;

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		velocityText = GameObject.Find("VelocityText").GetComponent <Text> ();
		positionText = GameObject.Find("PositionText").GetComponent <Text> ();

		rigidBody = GetComponent <Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxisRaw ("Horizontal");
		if (x > 0) {
			rigidBody.drag = dragUsingFan;
			rigidBody.AddForce(fanPower);
			useRightFan = true;
		} else if (x < 0) {
			var p = new Vector2(-1 * fanPower.x, fanPower.y);
			rigidBody.drag = dragUsingFan;
			rigidBody.AddForce(p);
			useLeftFan = true;
		} else {
			rigidBody.drag = 1;
		}

		velocityText.text = rigidBody.velocity.y.ToString("####0.00 m/s");
		positionText.text = rigidBody.position.y.ToString("####0.00 m");
	}

	void FixedUpdate() {
		if (useRightFan || useLeftFan) {
			return;
		}

		if (useRightFan) {
			useRightFan = false;
		}

		if (useLeftFan) {
			useRightFan = false;
		}
	}
}
