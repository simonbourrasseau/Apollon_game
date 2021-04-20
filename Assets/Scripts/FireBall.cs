using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

	public float speed;
	public Transform[] waypoints;
	
	private Transform target;
	private int destPoint = 0;
	
	void Start()
	{
		target =  waypoints[1];
	}
	
	void Update()
	{
		Vector3  dir = target.position - transform.position;
		//Debug.Log(dir);
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		
		//Debug.Log(Vector3.Distance(transform.position, target.position));
		
		if(Vector3.Distance(transform.position, target.position) < 0.3f)
        	{
            		//destPoint = (destPoint + 1) % waypoints.Length;
			//target = waypoints[destPoint];
			
			transform.position = GameObject.Find("Waypoint1").transform.position;
		}
	}

}


