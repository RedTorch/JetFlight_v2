using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* purpose of script is mainly just to update the background camera 
each fixedUpdate (in sync with the cinemachine-controlled game cam)
to prevent jittering. NOTE: to prevent jittering issues, any
update-sensitive behaviors such as movement must happen in fixedUpdate
(the only reason that this was not an issue in my first version was 
that, at the time, I was in the habit of using FixedUpdate() for 
everything (instead of Time.deltaTime)) */

public class BgCameraManager : MonoBehaviour
{
    [SerializeField] private Transform myGameCam;
    [SerializeField] private Vector3 cameraOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = myGameCam.position + cameraOffset;
        transform.rotation = myGameCam.rotation;
    }
}
