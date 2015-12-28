using UnityEngine;
using System.Collections;

public class DestroyerObject : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("relative velocity" + col.relativeVelocity);
        if (col.gameObject.GetComponent<Destroyable>() && col.relativeVelocity.magnitude > col.gameObject.GetComponent<Destroyable>().GetBreakPoint())
            col.gameObject.GetComponent<Destroyable>().Splinter();
    }

    void DoActivation()
    {
        gameObject.rigidbody.useGravity = true;
    }
}
