using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {
    public Transform cam;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	float rotationY = 0F;

	void Update ()
	{
		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
		
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        cam.localEulerAngles = new Vector3(-rotationY, 0, 0);
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}