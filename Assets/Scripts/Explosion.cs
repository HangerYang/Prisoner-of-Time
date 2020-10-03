using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Boom());
	}
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
        // Update is called once per frame
        void Update () {
		
	}
}
