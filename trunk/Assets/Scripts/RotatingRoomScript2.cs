using UnityEngine;
using System.Collections;

public class RotatingRoomScript2 : MonoBehaviour {
	public GameObject[] KeyPoints;
    public bool Rotating;
    public int currentRotation = 0;
    public float speed = 0.005f;
	
	// Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (Rotating)
        {
			foreach( Rigidbody rb in FindObjectsOfType( typeof( Rigidbody ) ) ) {
				rb.WakeUp();
			}
			Physics.gravity = Vector3.RotateTowards( Physics.gravity, KeyPoints[currentRotation].transform.up, speed, 0.0f );
			
			if ( Vector3.Angle( Physics.gravity.normalized, KeyPoints[currentRotation].transform.up ) <= 0.1f )
            {				
				Physics.gravity = KeyPoints[ currentRotation ].transform.up * Physics.gravity.magnitude;
				
				if( KeyPoints[currentRotation].GetComponent<RotationScript>().stopsRotation ) {
					Rotating = false;
				}
				
				currentRotation = ( currentRotation + 1 ) % KeyPoints.Length;
            }
        }
    }

    void OnGUI()
    {
        if (!Rotating)
        {
            if (GUI.Button(new Rect(0, 0, 128, 32), "Start rotation")) {				
                Rotating = true;
			}
        } else
            if (GUI.Button(new Rect(0, 0, 128, 32), "Stop rotation"))
                Rotating = false;
    }
}
