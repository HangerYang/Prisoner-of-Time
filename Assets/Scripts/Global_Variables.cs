using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global_Variables : MonoBehaviour {
    public static bool TimeStop = false;
    public static int Moves;
    private static bool Started = true;
    public static bool TimeReleased = false;
    AudioSource audiodata;
    [SerializeField] Camera Eye;

    

    // Use this for initialization
    void Start () {
        Moves = 0;
        audiodata = GetComponent<AudioSource>();
        BlackScreen();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Eye.transform.position;
        Moves = 0;
        if(!Started && Moves > 0) {
            Started = true;
            StartCoroutine(PlayerMoveTime());
            Moves = 0;
        }
         NextRoom();
    }
    
    public void StopObjects()
    {
        TimeStop = true;
        StartCoroutine(aud());
        TimeStop[] Stops = Object.FindObjectsOfType<TimeStop>();
        for (int i = 0; i < Stops.Length; i++)
        {
            Stops[i].Stop();
        }
        Moves = 0;
        Started = false;
    }

    IEnumerator PlayerMoveTime()
    {
        yield return new WaitForSeconds(15f);
        TimeStop = false;
        ReleaseObjects();
    }
    IEnumerator ReleaseObjectsTime()
    {
        yield return new WaitForSeconds(15f);
        
    }
    IEnumerator aud()
    {
        yield return new WaitForSeconds(1f);
        audiodata.Play(0);
    }
    IEnumerator EyeClose()
    {
        yield return new WaitForSeconds(3f);
        Eye.cullingMask = LayerMask.NameToLayer("Beep Boop Please Return -1");
        yield return new WaitForSeconds(2f);
        StopObjects();
    }
    IEnumerator OpenDoor()
    {
        yield return new WaitForSeconds(6f);
        Judge.PlayerWin = false;
        TimeReleased = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReleaseObjects()
    {
        TimeStopRelease[] Releases = Object.FindObjectsOfType<TimeStopRelease>();
        for (int i = 0; i < Releases.Length; i++)
        {
            Releases[i].Release();
        }
        TimeReleased = true;
        StartCoroutine(ReleaseObjectsTime());
        Judge.Onetime = true;
    }
    public void NextRoom()
    {
        if(Judge.PlayerWin)
        {
            StartCoroutine(OpenDoor());
        }
    }
    public void BlackScreen()
    {
        Debug.Log(Eye.cullingMask = LayerMask.NameToLayer("Default"));
        StartCoroutine(EyeClose());
    }
}
