using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_EnemyManager : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;

    [SerializeField] private Flyer_PodManager primary;
    [SerializeField] private Flyer_PodManager secondary;
    [SerializeField] private Flyer_PodManager equipment;

    [SerializeField] private Transform target;

    private float triggerTime = 0f;
    private float triggerInterval = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        myFc.SetRotationTarget(target.position);
        myFc.SetThrust(true);

        if(triggerInterval <= 0f)
        {
            primary.SetFire(true);
            triggerTime -= Time.deltaTime;
            if(triggerTime <= 0f)
            {
                primary.SetFire(false);
                triggerInterval = 3f;
                triggerTime = 1f;
            }
        }
        else{
            triggerInterval -= Time.deltaTime;
        }
        secondary.SetFire(false);
        equipment.SetFire(false);
    }

    public string GetDebugString() {
        string ret = "Flyer_EnemyManager [" + gameObject.name + "]";
        ret += "\n\nPRIMARY: " + (primary ? primary.GetDebugString() : "missing");
        ret += "\n\nSECONDARY: " + (secondary ? secondary.GetDebugString() : "missing");
        ret += "\n\nEQUIPMENT: " + (equipment ? equipment.GetDebugString() : "missing");
        return ret;
    }
}
