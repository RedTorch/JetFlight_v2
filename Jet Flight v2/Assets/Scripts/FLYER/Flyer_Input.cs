using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_Input : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;
    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        myFc.SetRotationTarget(mainCam.ScreenToWorldPoint(Input.mousePosition));
        myFc.SetThrust(Input.GetKey("z"));
    }
}
