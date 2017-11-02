using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //float roationSpeed = 10.0f;
    public float thrustForce = 5000f;
    public float breakVelocity = 0.95f;
    Rigidbody2D _rb;
    bool _isFiring;
    PlayerHandRotator _handrotation;
    /*bool bulletsleft;
    public float firerate = 0.05f;
    private float nextfire = 0.0f;*/
	// Use this for initialization
	void Start () {
        /*GameObject obj = GameObject.FindGameObjectWithTag("MainCamera");
        obj.gameObject.SendMessage("Start");
        obj.gameObject.SendMessage("GoToPlayer");*/
        _rb = GetComponent<Rigidbody2D>();
        _handrotation = GetComponentInChildren<PlayerHandRotator>();
	}
	
	// Update is called once per frame

    void Update()
    {
        /*if (Input.GetAxis("Fire1") > 0 && Time.time > nextfire)
        {
            Fire();
            _isFiring = true;
            nextfire = Time.time + firerate;
        }
        else {
            _isFiring = false;
            
        }*/
    }
    void FixedUpdate()
    {
        /*Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));*/
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //float _vectorX = VectorX(positionOnScreen.x,mouseOnScreen.x);
 
        if (_isFiring == true)
        {

            //_rb.AddForce(transform.right * thrustForce * Time.deltaTime);
            float directionx = positionOnScreen.x - mouseOnScreen.x;
            float directiony = positionOnScreen.y - mouseOnScreen.y;
            _rb.AddForce(new Vector2( directionx* thrustForce,directiony*thrustForce),ForceMode2D.Impulse);
            //transform.position = Vector2.right * thrustForce * Time.deltaTime;
        }
        else { _rb.velocity = _rb.velocity * breakVelocity; }

        //transform.parent.position = transform.position;
    }

   /* public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }*/

    /*void Fire()
    {
        GameObject obj = PoolManager.current.GetBullet();
        if (obj == null) { bulletsleft = false; return; }
        else { bulletsleft = true; }
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //obj.transform.position = new Vector3(transform.FindChild , transform.position.y, transform.position.z);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }*/

    public void Shooting()
    {
        _isFiring = true;   
    }
    public void StopShooting()
    {
        _isFiring = false;
    }
}
