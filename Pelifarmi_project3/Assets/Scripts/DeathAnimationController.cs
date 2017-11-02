using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAnimationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf",0.1f);
	}
	
	// Update is called once per frame
	void DestroySelf()
    {
        Destroy(gameObject);
    }
}
