using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {

    public Vector3 Dforward;
    public float DScale;
    private Vector3 sPos;
    private Vector3 sLPos;
    // Use this for initialization
    void Start () {
        sLPos =GetComponent<Transform>().position - GetComponentInParent<Rigidbody>().position;
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<MeshRenderer>().enabled = Global_Variables.TimeStop;
        sPos = GetComponentInParent<Rigidbody>().transform.position;
        GetComponent<Transform>().rotation =Quaternion.LookRotation(Dforward);
        GetComponent<Transform>().position = new Vector3(sPos.x- (Dforward.x * GetComponent<Transform>().lossyScale.z/2)+sLPos.x, sPos.y - (Dforward.y * GetComponent<Transform>().lossyScale.z/2) + sLPos.y, sPos.z - (Dforward.z * GetComponent<Transform>().lossyScale.z/2) + sLPos.z);
        GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x, GetComponent<Transform>().localScale.y, DScale* GetComponent<Transform>().localScale.x*4);
        Debug.Log(transform.lossyScale);
    }
}