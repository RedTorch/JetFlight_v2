using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_PodManager : MonoBehaviour
{
    [SerializeField] private Flyer_FlightController myFc;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float capacity = 5f;
    [SerializeField] private float RPM = 120f;
    private float rechargeIncrement_RPM = 1f; // time in seconds between each firing
    [SerializeField] private float reloadTime = 2f; // time it takes to reload the entire magazine
    private float rechargeIncrement_reloadTime = 1f; // time it takes to reload each shell (= reloadTime / capacity)

    [SerializeField] private string[] ignoreTags;

    private bool active_isFiring = false;
    private bool enabled_isFiring = true;
    private float current_capacity = 0f;
    private float current_RPM = 0f;
    private float current_reloadTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rechargeIncrement_RPM = 60f/RPM;
        rechargeIncrement_reloadTime = reloadTime/capacity;
        current_capacity = capacity;
        ignoreTags = new string[] {myFc.gameObject.tag};
    }

    // Update is called once per frame
    void Update()
    {
        if(current_capacity < capacity) {
            current_reloadTime += Time.deltaTime;
            if(current_reloadTime >= rechargeIncrement_reloadTime) {
                current_reloadTime -= rechargeIncrement_reloadTime;
                current_capacity += 1f;
                // current_capacity = capacity;
            }
        }
        if(current_RPM <= rechargeIncrement_RPM) {
                current_RPM += Time.deltaTime;
            }
        if(active_isFiring && enabled_isFiring && current_RPM >= rechargeIncrement_RPM && current_capacity >= 1f) {
            // GameObject newBullet = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, transform.eulerAngles.z / 2f)));
            GameObject newBullet = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // GameObject newBullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if(newBullet.GetComponent<BulletController>()) {
                float addedV = Vector3.Project(myFc.getMyRb().velocity, transform.right).magnitude;
                newBullet.GetComponent<BulletController>().SetStartVelocity(addedV);
            }
            newBullet.GetComponent<BulletController>().SetIgnoreTags(ignoreTags);

            current_capacity -= 1f;
            current_RPM = Mathf.Clamp(current_RPM-rechargeIncrement_RPM, -rechargeIncrement_RPM, 0f);
        }
    }

    public void SetFire(bool newSetFire)
    {
        active_isFiring = newSetFire;
    }

    public bool GetIsFireReady()
    {
        return true;
    }

    public string GetDebugString()
    {
        string ret = "Flyer_PodManager [" + gameObject.name + "]\n";
        ret += "magazine.capacity: " + Mathf.Floor(current_capacity) + " / " + capacity + "\n";
        ret += "current-cycle.RPM: " + (Mathf.Floor((current_RPM * 100f))/100f) + " / " + (Mathf.Floor((rechargeIncrement_RPM * 100f))/100f) + "s\n";
        ret += "magazine.reload: " + Mathf.Floor((current_reloadTime * 100f))/100f + " / " + Mathf.Floor((rechargeIncrement_reloadTime * 100f))/100f + "s";
        return ret;
    }
}
