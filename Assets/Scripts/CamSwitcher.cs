using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Camera;

public class CamSwitcher : MonoBehaviour {
	public bool isMain;
	public GameObject maincam;
	public GameObject seccam;
	Camera m,s;


	// Use this for initialization
	void Start () {
		isMain = true;
		m = maincam.GetComponent<Camera> ();
		s = seccam.GetComponent<Camera> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp ("space")) {
			isMain = !isMain;
		}

		if (isMain == true) {
			m.enabled = true;
			s.enabled = false;
		} else {
			m.enabled = false;
			s.enabled = true;;
		}

	}
}

