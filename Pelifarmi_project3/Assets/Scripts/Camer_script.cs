using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camer_script : MonoBehaviour {
    Transform player;
   /* public float leftLimitterX = -1000f;
    public float RightLimitterX = 1000f;
    public float UpLimitterY = 1000f;
    public float DownLimitterY = -1000f;*/
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
        if (player == null)
        {
            GameObject player_go = GameObject.FindGameObjectWithTag("Player");
            player = player_go.transform;
            offsetX = transform.position.x - player.position.x;
            offsetY = transform.position.y - player.position.y;
        }
        if (player != null)
        {
            Vector3 _tmp = Camera.main.WorldToScreenPoint(new Vector3(player.position.x, player.position.y, 0));
            Vector3 pos = transform.position;
            pos.y = player.position.y + offsetY;
            pos.x = player.position.x + offsetX;
            transform.position = pos;
            /*if (transform.position.x >= -leftLimitterX || transform.position.x >= RightLimitterX)
                {
                  
                }
            if (transform.position.y >= DownLimitterY || transform.position.y <= UpLimitterY)
            {
                pos.y = player.position.y + offsetY;
            }*/

            //Turhaa paskaa
           /* if (offsetX > leftLimitterX && offsetY < RightLimitterX)
            {
                      
            }

            if(offsetY > DownLimitterY && offsetY < UpLimitterY)
            {
                
            }*/
             //transform.position = new Vector3(Mathf.Clamp(pos.x, leftLimitterX, RightLimitterX),(Mathf.Clamp(pos.y, DownLimitterY, UpLimitterY)));
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
