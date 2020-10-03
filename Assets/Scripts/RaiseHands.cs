using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaiseHands : MonoBehaviour {
    [SerializeField] Transform LC;
    [SerializeField] Transform RC;
    [SerializeField] Transform H;
    [SerializeField] GameObject Profile;
    bool IN;
    public int Counter = 0;
    AudioSource audioData;
    [SerializeField] AudioSource audioData2;
    [SerializeField] AudioSource audioData3;
    private bool NextClipAV=false;
    private bool NextClip=true;
    // Use this for initialization
    void Start () {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(20f);
        audioData2.Play(0);
        yield return new WaitForSeconds(4f);
        NextClipAV = true;
    }
    // Update is called once per frame
    void Update () {
        IN = Counter > 10;
        if (IN&&NextClipAV){
            if (NextClip){
                NextClip = false;
                audioData3.Play(0);
            }
        }

		if (LC.position.y>H.position.y && RC.position.y > H.position.y && IN)
        {
            Profile.GetComponent<MeshRenderer>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
