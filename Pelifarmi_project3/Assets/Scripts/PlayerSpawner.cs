using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    public GameObject Player;
    //public GameObject PlayerCamera;
	// Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");
        if (player_go == null)
        {
            SpawnPlayer();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void SpawnPlayer()
    {
        GameObject clone;
        clone = Instantiate(Player, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity) as GameObject;
        clone.transform.eulerAngles = new Vector3(0, 0, 0);
    }

  /*  void SpawnCamera()
    {
        GameObject clone2;
        clone2 = Instantiate(PlayerCamera, new Vector3(transform.position.x, transform.position.y, -11), Quaternion.identity) as GameObject;
        clone2.transform.eulerAngles = new Vector3(0, 0, 0);
    }*/
}
