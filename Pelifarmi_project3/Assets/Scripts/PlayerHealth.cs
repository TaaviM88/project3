using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
    public int MaxHealth = 100;
	public int currentHealth;
    public int healtRestore = 20;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
    public AudioClip healthpickupSFX;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public int extraTime = 10;
    private UIGameOver _gameover;
	//Animator anim;
	AudioSource playerAudio;
	//controller
	//PlayerController playerMovement;
	//PlayerShooting playerShooting;
	bool isDead;
	bool damaged;
    GameManager _gameManager;


	void Awake ()
	{
		//anim = GetComponent <Animator> ();
		//Audio
		playerAudio = GetComponent <AudioSource> ();
		//playerMovement = GetComponent <PlayerMovement> ();
		//playerShooting = GetComponentInChildren <PlayerShooting> ();
		currentHealth = startingHealth;
        _gameover = GameObject.Find("GameOver").GetComponent<UIGameOver>();
        
	}


	void Update ()
	{
        if (_gameover == null)
        {
            Debug.Log("Voi vittu");
            _gameover = GameObject.Find("GameOver").GetComponent<UIGameOver>();
        }
        
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
        Debug.Log(currentHealth);
		damaged = false;
	}


	public void TakeDamage (int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;
		//Audio
		//playerAudio.Play ();

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}


	void Death ()
	{
		isDead = true;
        RestartLevel();

		//anim.SetTrigger ("Die");

		//audio
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();

		//controller
		//playerController.enabled = false;

	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "HealthPickUp")
        {
            if (currentHealth < MaxHealth)
            {
                currentHealth += healtRestore;
                playerAudio.PlayOneShot(healthpickupSFX);
            }
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "TimePickUp")
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (_gameManager == null)
            { Debug.Log("Ei löydy!"); }
            _gameManager.AddTime(extraTime);
            playerAudio.PlayOneShot(healthpickupSFX);
            
            Destroy(col.gameObject);
        }
    }
	public void RestartLevel ()
	{
        //_gameover.Show();
		SceneManager.LoadScene ("Credits");
	}
}
