using UnityEngine;

public class Seek : Behavior 
{
	public override Steering GetSteering() 
	{
		Steering steering = new Steering();

		steering.LinearMovement = Target.transform.position - 
		transform.position;
		
		steering.LinearMovement.Normalize();
		steering.LinearMovement = steering.LinearMovement * 
		agent.MaximumAcceleration;

		return steering;
	}	
}
