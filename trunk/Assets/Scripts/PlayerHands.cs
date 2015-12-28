using UnityEngine;
using System.Collections;

public class PlayerHands : MonoBehaviour {
    public Transform Player;
    public Transform currentLedge;    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GrabThis(Transform grabTransform)
    {
        currentLedge = grabTransform;
        Player.forward = -currentLedge.forward;
        Debug.Log("I AM GRABBING!!! @" + grabTransform);
    }
}
