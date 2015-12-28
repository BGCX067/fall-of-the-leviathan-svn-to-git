using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
    public enum MATERIAL { GLASS, WOOD, METAL };
    public MATERIAL material;
    public int breakpoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Splinter()
    {
        switch (material)
        {
            case MATERIAL.GLASS:
                Debug.Log("BREAK AS GLASS!");
                break;
            
            case MATERIAL.WOOD:
                Debug.Log("BREAK AS WOOD!");
                break;

            case MATERIAL.METAL:
                Debug.Log("BREAK AS METAL!");
                break;

            default:
                Debug.Log("NO MATERIAL DEFINED!!!");
                break;
        }
        Destroy(this.gameObject);
    }

    public int GetBreakPoint()
    {
        return breakpoint;
    }
}
