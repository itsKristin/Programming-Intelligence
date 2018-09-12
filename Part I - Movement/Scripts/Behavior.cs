using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {

	GameObject target;

	public GameObject Target 
	{
		get{ return target;}
		set{ target = value;}
	}

	protected Agent agent;

	public virtual void Awake()
	{
		agent = GetComponent<Agent>();
	}

	public virtual void Update()
	{
		agent.SetSteering(GetSteering());
	}

	public virtual Steering GetSteering()
	{
		return new Steering();
	}
}
