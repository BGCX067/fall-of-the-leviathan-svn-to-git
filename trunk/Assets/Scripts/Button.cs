using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
    public GameObject target;
    public bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        target.SendMessage("DoActivation");

        activated = true;
    }
}
