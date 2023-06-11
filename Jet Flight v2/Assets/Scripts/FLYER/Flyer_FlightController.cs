using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Flyer_FlightController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private TrailRenderer myTr;

    [Header("Thrust + Drag")]
    [SerializeField] private float maxThrust = 10f;
    [SerializeField] private float dragCoeff = 1f;
    [SerializeField] private float liftCoeff = 1f;

    [Header("Maneuverability")]
    [SerializeField] private float rotationSpeed = 180f;

    private bool enabled_Rotation = true;
    private bool enabled_Thrust = true;
    private bool enabled_Drag = true;

    private bool active_Thrust = false;

    private float goalRotation = 0f;

    private float multiplier_Drag_onThrustEnabled = 1f;
    private float multiplier_RotateSpeed_onThrustEnabled = 1f;
    // Start is called before the first frame update
    void Start()
    {
        liftCoeff = 0.8f * dragCoeff / maxThrust;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    void FixedUpdate() {
        if(enabled_Rotation) {
            multiplier_RotateSpeed_onThrustEnabled = active_Thrust ? 1f : 2f;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, goalRotation), rotationSpeed * multiplier_RotateSpeed_onThrustEnabled * Time.deltaTime);
        }
        if(enabled_Drag) {
            float angleOfAttack = Mathf.Clamp(Vector2.Angle(transform.right, myRb.velocity), 0f, 90f);
            float speed = myRb.velocity.magnitude;
            multiplier_Drag_onThrustEnabled = active_Thrust ? 1f : 0.25f;
            // myRb.AddForce(dragCoeff * Mathf.Pow(speed, 2f) * (0.5f + (angleOfAttack/90f)));
            myRb.drag = dragCoeff * Mathf.Pow(speed, 2f) * (0.5f + (angleOfAttack/90f)) * multiplier_Drag_onThrustEnabled;
        }
        if(enabled_Thrust && active_Thrust) {
            myRb.AddForce(transform.right * maxThrust);
            myTr.emitting = true;
        } else {
            myTr.emitting = false;
        }
    }

    private void update_GravityPhysics() {
        // calculations for key values
        float angleOfAttack = Mathf.Clamp(Vector2.Angle(transform.right, myRb.velocity), 0f, 90f);
        float angleToVertical = Vector2.Angle(Vector2.up, myRb.velocity);
        float dragArea = Mathf.Sin(Mathf.Deg2Rad * angleOfAttack);
        float speed = myRb.velocity.magnitude;
        // aerodynamic drag
            // calculate total area (which is the angle between velocity and heading (rotation))
        myRb.drag = dragCoeff * Mathf.Pow(speed, 2f) * (0.5f + (angleOfAttack/90f));
        // aerodynamic lift calculated off of over-wing airflow = velocity * angle of attack; if below certain amount, give stall alert
        float liftForce = liftCoeff * Mathf.Pow(speed, 2f) * (angleToVertical/90f);
        myRb.AddForce(Vector2.up * liftForce);
        // myRb.AddForce();
    }

    private void setGravity(float newG = 1f) {
        myRb.gravityScale = newG;
    }

    public void SetRotationTarget(Vector3 targetPositionInWorld) {
        Vector2 relativeTargetPosition = new Vector2(targetPositionInWorld.x - transform.position.x, targetPositionInWorld.y - transform.position.y);
        relativeTargetPosition.Normalize();
        goalRotation = Mathf.Atan2(relativeTargetPosition.y, relativeTargetPosition.x) * Mathf.Rad2Deg;
    }

    public void SetThrust(bool isThrust) {
        active_Thrust = isThrust;
    }

    public string GetDebugString() {
        string ret = "Flyer_FlightController [" + gameObject.name + "]\n" + "Velocity: " + myRb.velocity.magnitude;
        return ret;
    }

    public Rigidbody2D getMyRb()
    {
        return myRb;
    }
}