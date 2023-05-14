using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_PodManager : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float capacity = 5f;
    [SerializeField] private float RPM = 120f;
    private float rechargeIncrement_RPM = 1f; // time in seconds between each firing
    [SerializeField] private float reloadTime = 2f;
    private float rechargeIncrement_reloadTime = 1f; // time it takes to reload each shell

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
    }

    // Update is called once per frame
    void Update()
    {
        if(current_capacity < capacity) {
            current_reloadTime += Time.deltaTime;
            if(current_reloadTime >= rechargeIncrement_reloadTime) {
                current_reloadTime -= reloadTime;
                current_capacity += 1f;
            }
        }
        if(current_RPM <= rechargeIncrement_RPM) {
                current_RPM += Time.deltaTime;
            }
        if(active_isFiring && current_RPM >= rechargeIncrement_RPM && current_capacity >= 0f) {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            current_capacity -= 1f;
            current_RPM = 0f;
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
        ret += "capacity: " + Mathf.Floor(current_capacity) + " / " + capacity + "\n";
        ret += "RPM: " + (Mathf.Floor((current_RPM * 100f))/100f) + " / " + (Mathf.Floor((rechargeIncrement_RPM * 100f))/100f) + "\n";
        ret += "reload: " + (Mathf.Floor((current_reloadTime * 100f))/100f) + " / " + (Mathf.Floor((rechargeIncrement_reloadTime * 100f))/100f);
        return ret;
    }
}
