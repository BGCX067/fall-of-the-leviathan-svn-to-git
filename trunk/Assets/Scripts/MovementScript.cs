using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {	
	public float groundedDistance = 2.0f;
	public float speed;
	public float jumpSpeed;
	public float sideStepSpeed;
	public float maxVelocity;
	public float deceleration = 1.5f;
	public float sideStepDeceleration = 3.0f;
	
	// Use this for initialization
	void Start () { }
	
	void FixedUpdate()
	{
		// Shoot a ray downward to see if we're touching the ground
		bool grounded = Physics.Raycast (
			rigidbody.transform.position + rigidbody.transform.up,
			-rigidbody.transform.up,
			groundedDistance
		);
		
		if (grounded)
		{
			// Handle jumping
			if (Input.GetButtonDown ("Jump"))
			{
				rigidbody.AddForce( rigidbody.transform.up * jumpSpeed, ForceMode.Impulse );
			}
			// Handle walking
			else
			{				
				Vector3 movement = transform.forward * Input.GetAxis("Vertical") * speed;
				movement += transform.right * Input.GetAxis("Horizontal") * sideStepSpeed;
				
				if (!Input.GetButton("Vertical")) {
					movement += Vector3.Project(-rigidbody.velocity * deceleration, transform.forward);
				}
				
				if (!Input.GetButton("Horizontal")) {
					movement += Vector3.Project(-rigidbody.velocity * sideStepDeceleration, transform.right);
				}
				
				rigidbody.AddForce(movement, ForceMode.Acceleration);
				
				// Check to see if we're going too fast
				if( rigidbody.velocity.magnitude > maxVelocity )
				{
					// If we are, then we add a force that will stabilize the player
					rigidbody.AddForce( -( rigidbody.velocity - rigidbody.velocity.normalized * maxVelocity), ForceMode.Acceleration );
				}
			}
		}
	}
}
