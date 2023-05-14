using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugConsoleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text debugTextWindow;
    [SerializeField] private GameObject selectedFlyer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string txt = "DEBUG [" + selectedFlyer.name + "]";
        if(selectedFlyer.GetComponent<Flyer_FlightController>()) {
            txt += "\n" + selectedFlyer.GetComponent<Flyer_FlightController>().GetDebugString();
        }
        if(selectedFlyer.GetComponent<Flyer_PlayerManager>()) {
            txt += "\n" + selectedFlyer.GetComponent<Flyer_PlayerManager>().GetDebugString();
        }
        debugTextWindow.text = txt;
    }
}
