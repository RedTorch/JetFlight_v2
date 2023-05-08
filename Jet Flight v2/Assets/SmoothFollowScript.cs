using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowScript : MonoBehaviour
{
    [SerializeField] private Transform transformToFollow;
    [SerializeField] private Rigidbody2D rigidbodyToFollow;
    [SerializeField] private float smoothTime = 1f;
    [SerializeField] private Vector3 offset;

    private string toPrint = "";

    private Vector3 ref_CurrV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, transformToFollow.position, ref ref_CurrV, smoothTime) + offset;
        toPrint = $"Positions: transform, rigidbody\nFixed: {transformToFollow.position}, {rigidbodyToFollow.position}";
    }

    void LateUpdate()
    {
        print(toPrint + $"\nLate: {transformToFollow.position}, {rigidbodyToFollow.position}");
    }
}
