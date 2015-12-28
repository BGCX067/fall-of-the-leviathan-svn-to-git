using UnityEngine;
using System.Collections;

public class LedgeScript : MonoBehaviour {
    public int maxAngleBetweenPlayerAndThis = 15;

    void OnTriggerEnter(Collider hit){
        if (hit.gameObject.name == "PlayerHands")
        {
            int currentAngle = (int)Vector3.Angle(transform.up, hit.transform.up);
            Debug.Log(currentAngle);
            if (maxAngleBetweenPlayerAndThis >= currentAngle && -maxAngleBetweenPlayerAndThis <= currentAngle)
            {
                Debug.Log("This is certainly graBbababable! The angle between us: " + Vector3.Angle(transform.up, hit.transform.up));
                hit.gameObject.SendMessage("GrabThis", transform);
            }
        }
    }
}
