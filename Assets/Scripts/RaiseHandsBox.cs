using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseHandsBox : MonoBehaviour {

    [SerializeField] RaiseHands hands;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("AA");
        if (other.gameObject.tag == "Soul")
        {
            hands.Counter += 1;
            Debug.Log("A");
        }
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("BB");
        if (other.gameObject.tag == "Soul")
        {
            hands.Counter += 1;
            Debug.Log("B");
        }
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("CC");
        if (other.gameObject.tag == "Soul")
        {
            hands.Counter = 0;
            Debug.Log("C");
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
