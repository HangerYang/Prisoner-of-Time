using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour {

    public Vector3 TVelocity;
    public Vector3 TAngularVelocity;
    public Vector3 SVelocity;
    public Vector3 SAngularVelocity;
    public bool UseGrav;
    [SerializeField] public bool Grabbable;   

    void Start () {

    }
	
	void Update () {
        if (Global_Variables.TimeStop){
            DrawLine Line = GetComponentInChildren<DrawLine>();
            Line.Dforward = TVelocity.normalized;
            Line.DScale=TVelocity.magnitude;
        }
    }

    public void Stop()
    {
        SVelocity = GetComponent<Rigidbody>().velocity;
        SAngularVelocity = GetComponent<Rigidbody>().angularVelocity;
        TVelocity = SVelocity;
        TAngularVelocity = SAngularVelocity;
        UseGrav = GetComponent<Rigidbody>().useGravity;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}
