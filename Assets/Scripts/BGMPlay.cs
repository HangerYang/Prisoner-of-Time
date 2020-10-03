using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlay : MonoBehaviour {

    AudioSource audioData;
    // Use this for initialization
    void Start () {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (GunShoot.Shoot)
           if(audioData.pitch > 0.5)
                audioData.pitch -= 0.3f*Time.deltaTime;
        if (Global_Variables.TimeReleased)
            audioData.pitch = 1;
		
	}
}
