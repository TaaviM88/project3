using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf",1f);
	}
	
	// Update is called once per frame
	void DestroySelf()
    {
        Destroy(gameObject);
    }
}
