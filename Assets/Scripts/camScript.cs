using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {

	public Transform plr;
	public float smoothing = 5f;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - plr.position;
		
	}
	

	void FixedUpdate () {
		if (plr != null) {
			Vector3 target = plr.position + offset;
			transform.position = Vector3.Lerp (transform.position, target, smoothing * Time.deltaTime);
		}

		
	}
}
