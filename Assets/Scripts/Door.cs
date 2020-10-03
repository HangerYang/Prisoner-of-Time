using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    [SerializeField] Animator anim;
    AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Judge.PlayerWin)
        {
            DoorOpen();
            audioData.Play(0);
        }
	}

    private void DoorOpen()
    {
        anim.SetBool("Win", true);
    }
}



