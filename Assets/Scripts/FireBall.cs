using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		
		
		if(Vector3.Distance(transform.position, target.position) < 0.3f)
        	{
			transform.position = GameObject.Find("Waypoint1").transform.position;
		}
	}
	
    void OnTriggerEnter(Collider ball)
    {
     	if (ball.CompareTag("Player"))
	{
        	SceneManager.LoadScene("Final_Boss");
	}
    }
}


