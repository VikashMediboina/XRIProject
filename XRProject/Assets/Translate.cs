using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void translateVertical()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0)
        {
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y + (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y * 0.01f), transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        translateVertical();
    }
}
