using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour {
    public bool interacting;
    public bool handsInRange;
    public float chainReach;
    public float handsReach;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, fwd, out hit, chainReach))
        {
            if (Vector3.Distance(fwd, hit.point) <= handsReach)
            {
                Debug.Log("Hands can hit: " + hit.transform + " Distance: " + Vector3.Distance(fwd, hit.point));
                Debug.DrawLine(transform.position, hit.point, Color.green);
            } else if (Vector3.Distance(fwd, hit.point) > handsReach)
            {
                Debug.Log("Chain can hit: " + hit.transform + " Distance: " + Vector3.Distance(fwd, hit.point));
                Debug.DrawLine(transform.position, hit.point, Color.white);
            }
            
        }
    }
}
