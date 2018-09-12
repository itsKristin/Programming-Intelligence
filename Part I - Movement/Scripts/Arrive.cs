using UnityEngine;

public class Arrive : Behavior 
{
	[SerializeField] float targetRadius;
	[SerializeField] float slowingRadius;
	[SerializeField] float timeToTarget;

	public float TargetRadius{ get{ return targetRadius;}}
	public float SlowingRadius{ get{ return slowingRadius;}}
	public float TimeToTarget{ get{ return timeToTarget;}}

	Vector3 desiredVelocity;
	Vector3 currentDirection;
	float currentDistance;
	float targetSpeed;

	public override Steering GetSteering()
	{
		Steering steering = new Steering();

		currentDirection = Target.transform.position - 
		transform.position;
		currentDistance = currentDirection.magnitude;

		if(currentDistance < targetRadius)
		{
			return steering;
		}

		if(currentDistance > slowingRadius)
		{
			targetSpeed = agent.MaximumSpeed;
		} 
		else
		{
			targetSpeed = agent.MaximumSpeed * 
			currentDistance/slowingRadius;
		}

		desiredVelocity = currentDirection;
		desiredVelocity.Normalize();

		desiredVelocity *= targetSpeed;

		steering.LinearMovement = desiredVelocity - 
		agent.Velocity;
		steering.LinearMovement /= timeToTarget;

		if(steering.LinearMovement.magnitude > 
		agent.MaximumAcceleration)
		{
			steering.LinearMovement.Normalize();
			steering.LinearMovement *= agent.MaximumAcceleration;
		}

		return steering;
	} 	
}
