using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	[Header("Movement Settings:")]
	[SerializeField] float maximumSpeed;
	[SerializeField] float maximumAcceleration;
	[SerializeField] float orientation;
	[SerializeField] float rotation;
	[SerializeField] Vector3 velocity;

	protected Steering steering;

	Rigidbody rigidbody;

	Vector3 currentDisplacement;
	Vector3 currentOrientationVector3;

	public float MaximumSpeed {get{ return maximumSpeed;}}
	public float MaximumAcceleration {get{ return maximumAcceleration;}}
	public Vector3 Velocity {get{ return velocity;}}



	private void Start() 
	{
		rigidbody = GetComponent<Rigidbody>();
		velocity = Vector3.zero;
		steering = new Steering();
	}

	public virtual void Update()
	{
		
	}

	public virtual void FixedUpdate() 
	{
		if(!rigidbody)
		{
			return;
		}

		currentDisplacement = velocity * Time.deltaTime;
		orientation += rotation * Time.deltaTime;

		if(orientation < .0f)
		{
			orientation += 360.0f;
		} 
		else if (orientation > 360.0f)
		{
			orientation -= 360.0f;
		}

		rigidbody.AddForce(currentDisplacement, ForceMode.Force);

		currentOrientationVector3 = TransformOrientationToVector3(orientation);
		rigidbody.rotation = Quaternion.LookRotation(currentOrientationVector3, Vector3.up);
	}

	public virtual void LateUpdate()
	{
		velocity += steering.LinearMovement * Time.deltaTime;
		rotation += steering.AngularMovement * Time.deltaTime;

		if(velocity.magnitude > maximumSpeed)
		{
			velocity.Normalize();
			velocity = velocity * maximumSpeed;
		}

		if(!steering.IsMovingAngular())
		{
			rotation = .0f;
		}

		if(!steering.IsMovingLinear())
		{
			velocity = Vector3.zero;
		}

		steering = new Steering();
	}

	public void SetSteering(Steering _steering)
	{
		steering = _steering;
	}

	public Vector3 TransformOrientationToVector3(float _orientation)
	{
		Vector3 vector = Vector3.zero;

		vector.x = Mathf.Sin(_orientation * Mathf.Deg2Rad);
		vector.z = Mathf.Cos(_orientation * Mathf.Deg2Rad);

		return vector.normalized;
	}
}
