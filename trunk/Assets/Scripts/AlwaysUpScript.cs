using UnityEngine;
using System.Collections;

public class AlwaysUpScript : MonoBehaviour {
	
	public float speed = 0.01f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
//		transform.up = - Physics.gravity;
		Vector3 rotateAround = Vector3.Cross(transform.up, -Physics.gravity).normalized;
//		Debug.DrawLine(transform.position, transform.position + rotateAround, Color.red);
		transform.RotateAround(rotateAround, Vector3.Angle(transform.up, -Physics.gravity) * speed);
	}
}
