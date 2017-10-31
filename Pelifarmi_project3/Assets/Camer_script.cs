using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_script : MonoBehaviour {
    Transform player;
    float offsetX;
    float offsetY;
	// Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");
        if (player_go == null)
        {
            return;
        }

        player = player_go.transform;
        offsetX = transform.position.x - player.position.x;
        offsetY = transform.position.y - player.position.y;
	}
	
	// Update is called once per frame
	void Update () {
      
        if (player != null)
        {
            Vector3 _tmp = Camera.main.WorldToScreenPoint(new Vector3(player.position.x, player.position.y, 0));
            Vector3 pos = transform.position;
              if(transform.position.x >= -10 || transform.position.x >= 10)
                {
                pos.x = player.position.x + offsetX;         
                }
            if(transform.position.y >=-10 || transform.position.y <= 10)
            {
                pos.y = player.position.y + offsetY;
            }
             transform.position = pos;
            
        if (player == null)
        {
            return;
        }
       }
	}
    void GoToPlayer()
    {
        Vector3 po = transform.position;
        po.x = player.position.x + offsetX;
        po.y = player.position.y + offsetY;
        transform.position = po;
    }
}
