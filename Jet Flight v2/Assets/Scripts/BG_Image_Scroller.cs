using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BG_Image_Scroller : MonoBehaviour
{
    public Transform mainCam;
    private readonly float incrementX = 6.68f;
    private readonly float incrementY = 5.72f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tryScroll();
    }

    private void tryScroll()
    {
        if(Mathf.Abs(mainCam.position.x - transform.position.x) < incrementX && Mathf.Abs(mainCam.position.y - transform.position.y) < incrementY)
        {
            return;
        }
        float newX = mainCam.position.x - (mainCam.position.x % incrementX);
        float newY = mainCam.position.y - (mainCam.position.y % incrementY);
        Vector3 scrollPos = new Vector3(newX, newY, 0f);
        transform.position = scrollPos;
    }
}