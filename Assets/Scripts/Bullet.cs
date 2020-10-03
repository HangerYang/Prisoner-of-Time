using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float Speed;
	void Awake ()
    {
        Vector3 gotoPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        gotoPoint = new Vector3(gotoPoint.x, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position.y, gotoPoint.z);
        transform.LookAt(gotoPoint);
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward.normalized * Speed;
    }

}
