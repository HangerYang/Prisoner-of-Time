using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    [SerializeField] Transform Beakers;
    [SerializeField] float BeakerBreakForce;
    AudioSource audioData;
    // [SerializeField] Animator ani;//
    public bool BeakerBreak = false;

    void Start()
    {
        EyeClose();
        GetComponent<Rigidbody>().useGravity = true;
        audioData = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > BeakerBreakForce)
        {
            BeakerBreak = true;
            audioData.Play(0);
        }
    }

    IEnumerator EyeClose()
    {
        yield return new WaitForSeconds(0.1f);
       
    }
    void Update()
    {

    }
}
