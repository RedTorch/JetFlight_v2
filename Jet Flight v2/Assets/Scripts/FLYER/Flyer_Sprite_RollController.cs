using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_Sprite_RollController : MonoBehaviour
{
    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRollAnimation();
    }

    void UpdateRollAnimation(float rotationPercent = -1f) {
        if(rotationPercent == -1f) {
            rotationPercent = transform.rotation.eulerAngles.z / 360f;
        }
        myAnimator.Play("Roll_Animation", 0, rotationPercent);
    }
}