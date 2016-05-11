 using UnityEngine;
using System.Collections;


public class TargetFollower : MonoBehaviour {

	public GameObject target;

	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector3(target.transform.position.x,transform.position.y,transform.position.z);

	}

}
