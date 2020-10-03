using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {
    private bool GuardDead;
    AudioSource audiodata;
	// Use this for initialization
	void Start () {
        audiodata = GetComponent<AudioSource>();
        GuardDead = false;
        Vector3 gotoPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        gotoPoint = new Vector3(gotoPoint.x, transform.position.y, gotoPoint.z);
        transform.LookAt(gotoPoint);
        transform.forward = transform.forward;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!GuardDead)
        {
            if (collision.gameObject.tag == "Bullet" || collision.relativeVelocity.magnitude >= 6 || collision.gameObject.tag == "Chair")
            {
                audiodata.Play(0);
                GuardDead = true;
                Judge.EnemyNumber -= 1;
            }
        }
    }
    // Update is called once per frame
    void Update () {
	}
}
