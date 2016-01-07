using UnityEngine;
using System.Collections;

public class DieWhenFall : MonoBehaviour {

	// Use this for initialization
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -50) {
			transform.position = new Vector3(5f, 2f, 5f);
			transform.rotation = Quaternion.identity;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			GetComponent<move>().speed = 0f;
		}
	}
}
