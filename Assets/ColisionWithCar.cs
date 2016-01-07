using UnityEngine;
using System.Collections;

public class ColisionWithCar : MonoBehaviour {

	// Use this for initializatio

	// Update is called once per frame
	void Update () {
		//Vector3 lineBegin = new Vector3(transform.position.x, transform.position.y, transform.position.z+  GetComponent<Collider>().bounds.size.z/2);
		//Vector3 lineEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z+ GetComponent<Collider>().bounds.size.z/2+ GetComponent<move>().speed);

		if (GetComponent<move>().speed > 0) {
			Vector3 lineBegin = new Vector3(0,0,GetComponent<Collider>().bounds.size.z/2);
			Vector3 lineEnd = new Vector3(0,0,GetComponent<Collider>().bounds.size.z/2+ GetComponent<move>().translationAmount*3);

			// makes the line extend in the direction the car is facing
			lineBegin = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z)*lineBegin;
			lineEnd = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z)*lineEnd;	

			// makes the line translated to the car's position
			lineBegin.Set(lineBegin.x+ transform.position.x, lineBegin.y+ transform.position.y, lineBegin.z+ transform.position.z);
			lineEnd.Set(lineEnd.x+ transform.position.x, lineEnd.y+ transform.position.y, lineEnd.z+ transform.position.z);

			Debug.DrawLine(lineBegin, lineEnd, Color.red);
	    	if (Physics.Linecast(lineBegin, lineEnd)) {
            	Debug.Log("Touching");
            	GetComponent<move>().speed = -GetComponent<move>().speed/2;
    	    }
		}
	}
}
