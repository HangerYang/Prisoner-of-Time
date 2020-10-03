using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour {

    private Rigidbody rb;
    [SerializeField]private float Speed;
	void Start () {
        StartCoroutine(RunScientistRun());
        rb = GetComponent<Rigidbody>();

		
	}
	

    IEnumerator RunScientistRun()
    {
        yield return new WaitForSeconds(3f);
        rb.velocity = transform.forward * Speed * Time.deltaTime;
        


    }
}
