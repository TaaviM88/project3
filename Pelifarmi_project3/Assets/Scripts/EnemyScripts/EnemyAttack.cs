
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tämä POIS

public class EnemyAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;


	//Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	//EnemyHealth enemyHealth;
	bool playerInRange;
	float timer;


	void Start ()
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player != null)
        {
          
            playerHealth = player.GetComponent<PlayerHealth>();
        }
		//enemyHealth = GetComponent<EnemyHealth>();
		//anim = GetComponent <Animator> ();
	}


	void OnCollisionEnter2D (Collision2D other)
	{
		if(other.gameObject == player)
		{
			playerInRange = true;
		}
	}


	void OnCollisionExit2D (Collision2D other)
	{
		if(other.gameObject == player)
		{
			playerInRange = false;
		}
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange)
		{
			Attack ();
		}
		/*if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger ("PlayerDead");
		}*/
	}


	void Attack ()
	{
		timer = 0f;
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
