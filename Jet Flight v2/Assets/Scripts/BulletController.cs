using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class BulletController : MonoBehaviour
{
    [SerializeField] private float defaultSpeed = 10f;
    private float speed = 0f;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float damageAmount = 0f;
    private bool collisionActive = true;
    private float distanceTraveled = 0f;
    [SerializeField] private SpriteRenderer mySpriteRenderer;
    [SerializeField] private float expireTime = 2f;

    [SerializeField] private bool isTracking = false;
    [SerializeField] private Transform target;
    [SerializeField] private float trackSpeed = 50f; // in degrees per second
    private float expireTime_current = 2f;

    private Color myColor = Color.white;
    // Start is called before the first frame update

    private string[] ignoreTags;
    public AudioClip sound_hit;
    void Start()
    {
        expireTime_current = expireTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float travelDist = Time.fixedDeltaTime * speed;
        Vector2 currPos = transform.position;
        if(!collisionActive)
        {
            transform.Translate(Vector3.right * travelDist);
            float newScale = 0.3f * expireTime_current / expireTime;
            transform.localScale = new Vector3(newScale, newScale, 1f);
            // transform.Translate(transform.right * travelDist);
            // ^ match the above with the final movement code once decided
            expireTime_current -= Time.deltaTime;
            if(mySpriteRenderer)
            {
                myColor.a = expireTime_current / expireTime;
                mySpriteRenderer.color = myColor;
            }
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(currPos, transform.right, travelDist);
        // ^ this should hit both colliders and triggers (which are used to provide the missile hitbox, allowing them to be shot down)
        if(hit && !ignoreTags.Contains(hit.collider.gameObject.tag))
        {
            onValidCollision(hit);
        }
        else if(hit && ignoreTags.Contains(hit.collider.gameObject.tag))
        {
            print("invalid hit, target has ignored tag" + hit.collider.gameObject.tag);
        }

        if(isTracking && target)
        {
            trackTarget();
        }
        
        transform.Translate(Vector3.right * travelDist);
        distanceTraveled += travelDist;
        if(distanceTraveled >= maxDistance)
        {
            collisionActive = false;
            Destroy(gameObject,expireTime);
        }
    }

    public void SetStartVelocity(float velocityOfFlyer) 
    {
        speed = defaultSpeed + velocityOfFlyer;
    }

    public void SetIgnoreTags(string[] newTags)
    {
        ignoreTags = newTags;
    }

    private void trackTarget()
    {
        //rotate to face target
        Vector3 tPosition;
        tPosition.x = target.position.x - transform.position.x;
        tPosition.y = target.position.y - transform.position.y;
        float angle = Mathf.Atan2(tPosition.y, tPosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,angle), trackSpeed * Time.fixedDeltaTime);
    }

    private void onValidCollision(RaycastHit2D hit)
    {
        if(hit.collider.gameObject.GetComponent<Flyer_StatusManager>())
        {
            hit.collider.gameObject.GetComponent<Flyer_StatusManager>().TakeDamage(damageAmount);
        }
        transform.position = hit.point;
        AudioSource.PlayClipAtPoint(sound_hit, transform.position);
        Destroy(gameObject);
    }

}