using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    // Use this for initialization
    private SteamVR_TrackedObject trackedObj;
    //1
    private GameObject collidingObject;
    // 2
    private GameObject objectInHand;
    private Quaternion startRot1;
    private Quaternion startRot2;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    private void SetCollidingObject(Collider col)
    {
        // 1
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }
    // 1
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }
    private void GrabObject()
    {
        // 1
        if (collidingObject.GetComponent<TimeStop>().Grabbable)
        {
            Global_Variables.Moves += 1;
            objectInHand = collidingObject;
            collidingObject = null;
        // 2S
            startRot1 = transform.rotation;
            startRot2 = objectInHand.GetComponent<Transform>().rotation;
        }
    }

    // 3
    private void ReleaseObject()
    {
        objectInHand = null;
    }
    // Update is called once per frame
    void Update()
    {
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                if (Global_Variables.TimeStop)
                    GrabObject();
            }
        }

        // 2
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (objectInHand)
            {
                objectInHand.GetComponent<TimeStop>().SVelocity = Vector3.zero;
                objectInHand.GetComponent<TimeStop>().TVelocity = Vector3.zero;
                ReleaseObject();
            }
        }
        if (Global_Variables.TimeStop)
        {
            if (objectInHand.GetComponent<TimeStop>().Grabbable)
            {
                objectInHand.GetComponent<Transform>().position = transform.position;
                objectInHand.GetComponent<Transform>().rotation = transform.rotation;//Quaternion.Inverse(startRot2 * Quaternion.Inverse(startRot1) * transform.rotation);
                if (Controller.velocity.magnitude * 4 > objectInHand.GetComponent<TimeStop>().SVelocity.magnitude)
                {
                    objectInHand.GetComponent<TimeStop>().TVelocity = Controller.velocity.normalized * Controller.velocity.magnitude * 4;
                }
                else
                    objectInHand.GetComponent<TimeStop>().TVelocity = objectInHand.GetComponent<Transform>().forward * objectInHand.GetComponent<TimeStop>().SVelocity.magnitude;
            }
        }
        else
        {
            ReleaseObject();
        }
    }
}
