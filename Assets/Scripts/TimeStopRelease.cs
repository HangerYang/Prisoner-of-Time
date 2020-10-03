using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopRelease : MonoBehaviour {

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Release()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = GetComponent<TimeStop>().TVelocity;
        GetComponent<Rigidbody>().angularVelocity = GetComponent<TimeStop>().TAngularVelocity;
        GetComponent<Rigidbody>().useGravity = GetComponent<TimeStop>().UseGrav;
    }
}
