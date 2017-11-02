using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour {
    bool _isFiring;
    bool bulletsleft;
    public float firerate = 1f;
    private float nextfire = 0.0f;
    PlayerController _playermove;
    public AudioClip Shoot;
    private AudioSource source;
   
	// Use this for initialization
	void Start () {
       /* _playermove = GetComponent<PlayerController>();
        if (_playermove != null)
        { Debug.Log("GUUU	UUUUUF!"); }
        */
        _playermove = GetComponentInParent<PlayerController>();
        source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Fire1") > 0 && Time.time > nextfire)
        {
            Fire();
            _isFiring = true;
            nextfire = Time.time + firerate;
            if (_playermove != null)
            {
                MovePlayer();
            }
            if (_playermove == null)
            { Debug.Log("FUG"); _playermove = GetComponent<PlayerController>(); }
        }
        else
        {_isFiring = false;}

        if (_isFiring == false)
        {
            StopPlayer();
        }
	}

    void Fire()
    {
        GameObject obj = PoolManager.current.GetBullet();
        if (obj == null) { bulletsleft = false; return; }
        else { bulletsleft = true; }
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        source.PlayOneShot(Shoot);
    }

    void MovePlayer()
    {
        if (bulletsleft == true)
        {
            _playermove.Shooting();
        }
    }
    void StopPlayer()
    {
        _playermove.StopShooting();
    }
}
