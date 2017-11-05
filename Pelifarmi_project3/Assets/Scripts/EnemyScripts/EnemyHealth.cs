using System.Collections;
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
    public GameObject _healtDrop;
    public GameObject _timeDrop;
    private GameObject _Spawn;
    Score _score;
    public int _enemyScore = 10;
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = startingHealth;
        _score = GameObject.Find("ScoreManager").GetComponent<Score>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (_score == null)
        { _score = GameObject.Find("ScoreManager").GetComponent<Score>(); Debug.Log("Ei löydy scorea"); }
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
        _score.AddScore(_enemyScore);
        GeneratePowerUp();
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
    void GeneratePowerUp()
    {
        int getpwr = Random.Range(0, 100);

        if (getpwr <= 66)
        {
            SpawnPowerUp();
        }
        if (getpwr >= 80)
        {
            SpawnTime();
        }
    }
    void SpawnPowerUp()
    {
        _Spawn = Instantiate(_healtDrop, transform.position, Quaternion.identity) as GameObject;
    }
    void SpawnTime()
    {
        _Spawn = Instantiate(_timeDrop, transform.position, Quaternion.identity) as GameObject;
    }

}
