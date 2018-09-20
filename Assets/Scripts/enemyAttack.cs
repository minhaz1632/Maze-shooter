using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	Animator anim;
	GameObject player;
	playerHealth PlayerHealth;
	EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;


	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		PlayerHealth = player.GetComponent <playerHealth> ();
		enemyHealth = GetComponent<EnemyHealth>();
		anim = GetComponent <Animator> ();
	}


	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange  && enemyHealth.currentHealth > 0)
		{
			Attack ();
		}

		if(PlayerHealth.currentHealth <= 0)
		{
			//anim.SetTrigger ("PlayerDead");
			Destroy(player);
		
		}
	}


	void Attack ()
	{
		timer = 0f;

		if(PlayerHealth.currentHealth > 0)
		{
			PlayerHealth.TakeDamage (attackDamage);
		}
	}
}
