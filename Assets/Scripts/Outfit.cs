using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outfit : MonoBehaviour {

    private Renderer Render;
	void Start () {
        Render = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Global_Variables.TimeStop)
            Render.enabled = true;
        if (!Global_Variables.TimeStop)
            Render.enabled = false;
		
	}
}
