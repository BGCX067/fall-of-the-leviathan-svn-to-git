using UnityEngine;
using System.Collections;

public class RotatingRoomScript : MonoBehaviour {
    public GameObject[] KeyPoints;
    public bool Rotating;
    public int currentRotation = 0;
    public float speed = 1.0f;

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
			
			transform.rotation = Quaternion.RotateTowards( transform.rotation, KeyPoints[currentRotation].transform.rotation, 0.05f );
            //transform.rotation = Quaternion.Slerp( originalRotation, KeyPoints[currentRotation].transform.rotation, Time.deltaTime * speed);
            
            if (transform.rotation == KeyPoints[currentRotation].transform.rotation)
            {
                if(KeyPoints[currentRotation].GetComponent<RotationScript>().stopsRotation)
                    Rotating = false;
                if (KeyPoints[currentRotation + 1] != null)
                    currentRotation++;
                else
                    Rotating = false;
                Debug.Log("Current: " + currentRotation);
            }
        }
    }

    void OnGUI()
    {
        if (!Rotating)
        {
            if (GUI.Button(new Rect(0, 0, 128, 32), "Start rotation"))			
				Rotating = true;				
        } else
            if (GUI.Button(new Rect(0, 0, 128, 32), "Stop rotation"))
                Rotating = false;
    }
}
