using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneMovement : MonoBehaviour {

	Transform Gplayer;
	EnemyHealth enemyhealth;
	playerHealth playerhealth;
	NavMeshAgent nav;
	void Awake()
	{
		Gplayer = GameObject.FindGameObjectWithTag ("Player").transform;
		playerhealth = Gplayer.GetComponent <playerHealth> ();
		enemyhealth = GetComponent <EnemyHealth> ();
		nav = GetComponent<NavMeshAgent> ();
	}
		
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyhealth.currentHealth > 0 && playerhealth.currentHealth > 0) 
		{
			nav.SetDestination (Gplayer.position);

		} 
		else 
		{
			nav.enabled = false;
		}
	}
}
