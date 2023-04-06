using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_LoadoutHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPrimary(int val) {
        switch(val) {
            case 0:
                print("selected: Vulcan");
                break;
            case 1:
                print("selected: Prism");
                break;
            default:
                print("invalid selection");
                break;
        }
    }
}
