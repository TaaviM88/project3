using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
	public Transform _target;
    //PlayerController _target;
	public float speed = 2f;
	public float minDistance = 1f;
	private float range;
    GameObject player;

		void Start ()
		{
           //playerController _target = GetComponentInChildren<PlayerController>();
            player = GameObject.FindGameObjectWithTag("Player");
           
		}


        void Update()
        {
                _target = player.transform;
                range = Vector2.Distance(transform.position, _target.transform.position);

                if (range > minDistance)
                {
                    //Debug.Log(range);

                    transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
                }
   
        }
}
