using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginScript : MonoBehaviour
{
    bool Goto = true;
    [SerializeField] Camera eye;
    private void OnTriggerEnter(Collider other)
    {
        if (Goto == true)
        {
            Goto = false;
            eye.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}