using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_PlayerManager : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;
    [SerializeField] private Camera gameCam;

    [SerializeField] private Flyer_PodManager primary;
    [SerializeField] private Flyer_PodManager secondary;
    [SerializeField] private Flyer_PodManager equipment;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        myFc.SetRotationTarget(gameCam.ScreenToWorldPoint(Input.mousePosition));
        myFc.SetThrust(Input.GetKey("z"));
        primary.SetFire(Input.GetMouseButton(0));
        secondary.SetFire(Input.GetMouseButton(1));
        equipment.SetFire(Input.GetKey("x"));
    }

    public string GetDebugString() {
        string ret = "Flyer_PlayerManager [" + gameObject.name + "]";
        ret += "\n\nPRIMARY: " + (primary ? primary.GetDebugString() : "missing");
        ret += "\n\nSECONDARY: " + (secondary ? secondary.GetDebugString() : "missing");
        ret += "\n\nEQUIPMENT: " + (equipment ? equipment.GetDebugString() : "missing");
        return ret;
    }

    public Flyer_FlightController getMyFc() {
        return myFc;
    }
}
