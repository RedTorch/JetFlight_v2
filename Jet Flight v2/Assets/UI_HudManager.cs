using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/*
each of these UI component has a parent object that contains all elements and an animator possibly
UI elements (mainly alterts) can be hidden or shown
if an animator is present, animation will be restarted on show
*/

public class UI_HudManager : MonoBehaviour
{
    [SerializeField] private GameObject[] alerts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetAlert(string alertName, bool isShow)
    {
        foreach(GameObject alert in alerts)
        {
            if(alert.name == alertName)
            {
                alert.SetActive(isShow);
                if(alert.GetComponent<Animator>()) // if animator, restart looping anim
                {
                    if(isShow)
                    {
                        alert.GetComponent<Animator>().enabled = true;
                        alert.GetComponent<Animator>().Play(1);
                    }
                    else
                    {
                        alert.GetComponent<Animator>().enabled = false;
                    }
                }
                return true;
            }
        }
        return false;
    }
}
