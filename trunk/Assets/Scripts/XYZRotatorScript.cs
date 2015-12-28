using UnityEngine;
using System.Collections;

public class XYZRotatorScript : MonoBehaviour {
    public Transform globalRotation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.rotation = globalRotation.rotation;
	}
}
