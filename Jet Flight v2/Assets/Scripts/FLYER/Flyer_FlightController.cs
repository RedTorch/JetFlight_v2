using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_FlightController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private TrailRenderer myTr;
    private float maxThrust = 10f;
    private bool isThrust = true;
    private float dragCoeff = 1f;
    private float liftCoeff = 1f;

    private float bufferedRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // liftCoeff = 4.9f * dragCoeff / maxThrust;
        liftCoeff = dragCoeff / maxThrust;
        // liftCoeff = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        applyForces();
    }

    private void applyForces() {
        // rotate plane
        transform.Rotate(new Vector3(0f,0f, bufferedRotation));
        bufferedRotation = 0f;
        // engine thrust
        myTr.emitting = isThrust;
        if(isThrust) {
            myRb.AddForce(transform.right * maxThrust);
        }
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

    public void RotateByValue(float xInputVal) {
        bufferedRotation = xInputVal;
    }
}