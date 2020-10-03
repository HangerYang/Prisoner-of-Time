using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour {
    private Animator anim;
    void Start () {
         anim = GetComponent<Animator>();
         StartCoroutine(DoorClose());
	}
	
	// Update is called once per frame
IEnumerator DoorClose()
    {
        yield return new WaitForSeconds(3f);
        anim.SetBool("DoorClose", true);
        Debug.Log("DoorClose");

    }
}
