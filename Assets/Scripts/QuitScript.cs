using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Application.Quit();
    }
}

