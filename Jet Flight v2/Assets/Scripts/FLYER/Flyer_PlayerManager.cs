using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_PlayerManager : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;
    private Camera mainCam;

    [SerializeField] private Flyer_PodManager primary;
    [SerializeField] private Flyer_PodManager secondary;
    [SerializeField] private Flyer_PodManager equipment;
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
        primary.SetFire(Input.GetMouseButton(0));
        secondary.SetFire(Input.GetMouseButton(1));
        equipment.SetFire(Input.GetKey("x"));
    }

    public string GetDebugString() {
        string ret = "Flyer_PlayerManager [" + gameObject.name + "]";
        ret += primary ? "\nprimary: " + primary.GetDebugString() : "\nprimary: missing";
        ret += secondary ? "\nsecondary: " + secondary.GetDebugString() : "\nsecondary: missing";
        ret += equipment ? "\nequipment: " + equipment.GetDebugString() : "\nequipment: missing";
        return ret;
    }

    public Flyer_FlightController getMyFc() {
        return myFc;
    }
}
