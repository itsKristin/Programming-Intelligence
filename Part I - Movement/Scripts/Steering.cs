using UnityEngine;

public class Steering  
{
	float angularMovement;
	Vector3 linearMovement;

	public float AngularMovement 
	{
		get{ return angularMovement;} 
		set{ angularMovement = value;}
	}

	public Vector3 LinearMovement
	{
		get{ return linearMovement;} 
		set{ linearMovement = value;}
	}

	public Steering()
	{
		angularMovement = .0f;
		linearMovement = new Vector3();
	}

	public bool IsMovingAngular()
	{
		return angularMovement != .0f;
	}

	public bool IsMovingLinear()
	{
		return linearMovement.sqrMagnitude != .0f;
	}	
}
