using UnityEngine;

public class Pursue : Seek
{
	float maxPrediction;

	GameObject inputTarget;
	Agent targetAgent;

	Vector3 direction;
	float distance;
	float speed;
	float prediction;

	public float MaxPrediction {get{ return maxPrediction;}}

	public override void Awake()
	{
		base.Awake();

		targetAgent = Target.GetComponent<Agent>();
		inputTarget = Target;
		Target = new GameObject();
	}

	void OnDestroy() 
	{
		Destroy(inputTarget);	
	}

	public override Steering GetSteering()
	{
		direction = inputTarget.transform.position - transform.position;
		distance = direction.magnitude;
		speed = agent.Velocity.magnitude;

		if(speed <= distance/maxPrediction)
		{
			prediction = maxPrediction;
		} 
		else 
		{
			prediction = distance/speed;
		}

		Target.transform.position = inputTarget.transform.position;
		Target.transform.position += targetAgent.Velocity * prediction;
		return base.GetSteering();
	} 
}
