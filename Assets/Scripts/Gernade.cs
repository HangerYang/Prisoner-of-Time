using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gernade : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] Transform player;
    [SerializeField] Transform thing;
    [SerializeField] float secs;
    [SerializeField] GameObject Exp;
    AudioSource audioData;
    private Vector3 PosTo;
    // [SerializeField] Animator ani;//
    public float DetTime;
    bool det = true;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(EyeClose());
    }

    IEnumerator EyeClose()
    {
        yield return new WaitForSeconds(2.4f);
        PosTo = new Vector3(player.position.x + Random.Range(-0.25f, 0.25f), thing.position.y + Random.Range(-0.25f, 0.25f), player.position.z + Random.Range(-0.5f, 0f));
        Vector3 newPos = new Vector3(transform.position.x, thing.position.y, transform.position.z);
        transform.position = newPos;
        Vector3 v = (PosTo - transform.position) / (secs - 2.2f);
        v.y = 4.9f * (secs - 2.5f);
        rb.velocity = v;
    }
    IEnumerator Detonate()
    {
        yield return new WaitForSeconds(DetTime);
        Instantiate(Exp, transform);
    }
    void Update()
    {
        if (Global_Variables.TimeReleased && det)
        {
            det = false;
            StartCoroutine(Detonate());
        }
    }
}