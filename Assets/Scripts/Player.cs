using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 6f;

	Animator anim;
	Rigidbody Gplayer;
	Vector3 movement;
	int floorMask;
	float camRayLength=100f;


	void Awake()
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		Gplayer = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		Gplayer.MovePosition (transform.position + movement);
	}

	void Animating(float h, float v)
	{
		bool w = h != 0 || v != 0;
		anim.SetBool ("isRunning", w);
	}
	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorhit;

		if (Physics.Raycast (camRay, out floorhit, camRayLength, floorMask)) {
			Vector3 target = floorhit.point - transform.position;
			target.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation (target);
			Gplayer.MoveRotation (newRotation);


		}
	}

}
