using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_rigidbody3d_version : MonoBehaviour
{
    float roationSpeed = 10.0f;
    float thrustForce = 500f;
    Rigidbody _rb;
    bool _isFiring;
    bool bulletsleft;
    private float firerate = 0.05f;
    private float nextfire = 0.0f;
	// Use this for initialization
	void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("MainCamera");
        obj.gameObject.SendMessage("Start");
        obj.gameObject.SendMessage("GoToPlayer");
        _rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && Time.time > nextfire)
        {
            Fire();
            _isFiring = true;
            nextfire = Time.time + firerate;
        }
        else {
            _isFiring = false;
            
        }
    }
    void FixedUpdate()
    {
        Debug.Log(_rb.velocity);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y,angle));
        _rb.MoveRotation(Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y,angle)));

        if (_isFiring == true && bulletsleft)
        {
            _rb.AddForce(transform.right * thrustForce * Time.deltaTime);
            //transform.position = Vector2.right * thrustForce * Time.deltaTime;
        }
        else { _rb.velocity = _rb.velocity * 0.95f;}
    }

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void Fire()
    {
        GameObject obj = PoolManager.current.GetBullet();
        if (obj == null) { bulletsleft = false; return; }
        else { bulletsleft = true; }
        obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
