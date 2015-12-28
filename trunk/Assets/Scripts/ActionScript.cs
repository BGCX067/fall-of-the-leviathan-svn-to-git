using UnityEngine;
using System.Collections;

public class ActionScript : MonoBehaviour {
	
	public Transform Head;
	public float ActionRadius = 1;
	public float ActionRange = 2;
    public bool closeInteraction;
    public bool farInteraction;
	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        float distanceToGround; 
        if (Input.GetButtonDown("Action"))
        {
			RaycastHit[] hit = Physics.SphereCastAll(Head.position, ActionRadius, Head.forward, ActionRange);
			
			if (hit.Length > 0)
			{
				print(hit.Length);
                foreach (RaycastHit h in hit)
                {
                    if (h.transform.GetComponent<Button>())
                        h.transform.SendMessage("Activate");
                        //h.transform.GetComponent<Button>().Activated();
                    print(h.transform + " " + h.distance);
                }

			}
        }
//		print(Head.position);
		Debug.DrawLine(Head.position, Head.position + Head.forward * ActionRange, Color.white);
		Debug.DrawLine(Head.position + Head.up * ActionRadius, Head.position + Head.up * ActionRadius + Head.forward * ActionRange, Color.gray);
		Debug.DrawLine(Head.position - Head.up * ActionRadius, Head.position - Head.up * ActionRadius + Head.forward * ActionRange, Color.gray);

        closeInteraction = false;
        farInteraction = false;
    }
}
