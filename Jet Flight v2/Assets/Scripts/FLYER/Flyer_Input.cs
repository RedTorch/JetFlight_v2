using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_Input : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0f) {
            myFc.RotateByValue(-1f * Input.GetAxis("Horizontal"));
        }
    }
}
