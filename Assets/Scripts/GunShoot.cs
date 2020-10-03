using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour {
    [SerializeField] GameObject Bullets;
    Quaternion BulletRotation;
    AudioSource audioData;
    [SerializeField] GameObject offset;
    static public bool Shoot = false;

    // Use this for initialization
    void Start () {
        Shoot = false;
        StartCoroutine(EyeClose());
        audioData = GetComponent<AudioSource>();
        
    }


    IEnumerator EyeClose()
    {
        yield return new WaitForSeconds(4f);
        Instantiate(Bullets, offset.transform.position, BulletRotation);
        Shoot = true;
        audioData.Play(0);
    }
}
