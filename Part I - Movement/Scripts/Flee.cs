using UnityEngine;

public class Flee : Behavior 
{

	public override Steering GetSteering()
	{
		Steering steering = new Steering();

		steering.LinearMovement = transform.position - 
		Target.transform.position;

		steering.LinearMovement.Normalize();
		steering.LinearMovement = steering.LinearMovement * 
		agent.MaximumAcceleration;

		return steering;
	} 
}
