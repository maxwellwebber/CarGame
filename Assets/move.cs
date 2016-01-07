using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public float speed = 0;
	public float translationAmount = 0;
		float turn = 60;
		float accel = 0.1f;
		float maxSpeed = 5;
		float friction = .06f;
	void Start () {
		
	}
	// Update is called once per frame
	void Update () 
	{

		translationAmount = Time.deltaTime * speed;
		transform.Translate(Vector3.forward * translationAmount);

		if ((transform.rotation.eulerAngles.x % 270 < 90 && transform.rotation.eulerAngles.x % 270 > -90) && (transform.rotation.eulerAngles.z % 270 < 90 && transform.rotation.eulerAngles.z % 270 > -90)) //temporary fix, won't work upside down!!
		{
			if ((!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow))) {
				applyFriction();
			}  else {
				if (Input.GetKey(KeyCode.UpArrow)) {
					if (speed <= maxSpeed) {
    		 			speed += accel; 			
    		 		}
				}
				if (Input.GetKey(KeyCode.DownArrow)) {
    	 			if (speed >= -maxSpeed/5) {
    		 				speed -= accel;		 			
    	 			}
				}
			}		
			if (Input.GetKey(KeyCode.LeftArrow)) {
     			transform.Rotate(Vector3.up*-1 * Time.deltaTime*turn);
			}
			if (Input.GetKey(KeyCode.RightArrow)) {
    			transform.Rotate(Vector3.up * Time.deltaTime*turn);
			}				
		} else {
			applyFriction();
		}
	}

	void applyFriction() {
		if (speed > friction) {
			speed -= friction;
		} else if (speed < -friction) {
			speed += friction;
		} else {
			speed = 0;
		}
	} 
}
