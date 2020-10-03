using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
   
    static public bool Dead;
    static public bool SoulIn;
    [SerializeField] private GameObject Model;
    [SerializeField] private ParticleSystem p;
    int DeadCount = 0;
    void Start () {
        Dead = false;
        SoulIn = true;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Dead = true;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            SoulIn = true;
            
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            SoulIn = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.tag == "Soul")
        {
            SoulIn = false;
            
        }
    }

    // Update is called once per frame
    void Update () {
        var main = p.main;
        if (SoulIn)
        {
            main.startColor = new Color(0, 255, 0);
            Model.SetActive(false);
        }
        else
        {
            main.startColor = new Color(0, 255, 128);
            Model.SetActive(true);
        }

        if (Global_Variables.TimeReleased && !SoulIn)
        {         
                main.startColor = new Color(255,0,0);
                Dead = true;
                Debug.Log("SoulInDead");
        }
	}
}
