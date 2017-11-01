﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script_2 : MonoBehaviour {
    public Transform Player;
    public Vector2 Marging, Smoothing;
    public BoxCollider2D Bounds;
    private Vector3 _min, _max;
    public bool Isfollowing { get; set; }
	// Use this for initialization
	void Start () {
       Vector3 _min = Bounds.bounds.min;
       Vector3 _max = Bounds.bounds.max;
       Isfollowing = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var x = transform.position.x;
        var y = transform.position.y;

        if(Isfollowing)
        {
        if(Mathf.Abs(x - Player.position.x)>Marging.x)
            x = Mathf.Lerp(x,Player.position.x, Smoothing.x * Time.deltaTime);
        if(Mathf.Abs(y-Player.position.y) > Marging.y)
            y = Mathf.Lerp(y,Player.position.y, Smoothing.y * Time.deltaTime);
        }

        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float) Screen.width / Screen.height);
        x = Mathf.Clamp(x,_min.x+ cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y,_min.y + cameraHalfWidth , _max.y -cameraHalfWidth);
        transform.position = new Vector3(x,y,transform.position.z);
    }
}
