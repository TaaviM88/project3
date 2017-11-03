﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	public AudioClip deathClip;
    public int amount = 10;
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
    public GameObject explosionPrefab;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void TakeDamage ()
	{
		if(isDead)
			return;

		//enemyAudio.Play ();

		currentHealth -= amount;

		//hitParticles.transform.position = hitPoint;
		//hitParticles.Play();

		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;

		//anim.SetTrigger ("Dead");

		//enemyAudio.clip = deathClip;
		//enemyAudio.Play ();
        enemyAudio.PlayOneShot(deathClip);
        GameObject explosion = GameObject.Instantiate(explosionPrefab);
        explosion.transform.position = this.transform.position;
		Destroy (gameObject,0.1f);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            TakeDamage();
            coll.gameObject.SendMessage("Destroy",SendMessageOptions.DontRequireReceiver);
        }
    }


}
