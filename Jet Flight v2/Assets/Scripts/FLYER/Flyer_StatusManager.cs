using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer_StatusManager : MonoBehaviour
{
    [SerializeField] private float HP = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float dmg)
    {
        HP -= dmg;
        if(HP >= 0f)
        {
            // takeDamage visuals: create debris w/ inherited velocity, smoke, etc.
            // soundFx
            return;
        }
        // destruction
        if(gameObject.tag == "Player")
        {
            // handle player destruction: change camera target
            return;
        }
        // handle enemy destruction: score increase (if player kill)
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enemy" || other.gameObject.tag=="Player")
        {
            return;
        }
        Destroy(gameObject);
    }
}