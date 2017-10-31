using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    private float speed = 5f;
    public int powerUpInt = 0;
    private Vector3 bulletMovement;
    private Vector3 bulletRotation;
    private Vector2 _currentPosition;
    Vector2 positionOnScreen;
    Vector2 mouseOnScreen;
    float angle;
	// Use this for initialization
	void Start () {
        _currentPosition = transform.position;
       positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
       mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
       angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
	}
	
	// Update is called once per frame
	void Update () {
    
        /*transform.position += bulletMovement;
        transform.localRotation *= Quaternion.Euler(bulletRotation);*/
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //transform.position = 
	}

    public float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
