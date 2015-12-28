using UnityEngine;
using System.Collections;

public class InstantiatorScript : MonoBehaviour {
    public Transform cube;
	
    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Jump"))
            for(int i=0; i<100; i++)
                Instantiate(cube, transform.position, Quaternion.identity);
	}
}
