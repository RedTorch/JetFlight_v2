using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        SetStartVelocity(0f);
    }

    // Update is called once per frame
    void Update()
    {
        float travelDist = Time.deltaTime * speed;
        Vector2 currPos = transform.position;
        if(!collisionActive) {
            // fade bullet over [expireTime] seconds
            return;
        }
        OnHit(Physics2D.Raycast(currPos, transform.right, travelDist));
        transform.Translate(transform.right * travelDist);
        distanceTraveled += travelDist;
        if(distanceTraveled >= maxDistance) {
            ExpireBullet();
        }
    }

    public void SetStartVelocity(float addedVelocity) {
        speed = defaultSpeed + addedVelocity;
    }

    private void OnHit(RaycastHit2D hit) {
        return;
        if(hit)
        {
            transform.position = hit.point;
            if(hit.collider.gameObject.GetComponent<DamageReceiver>())
            {
                hit.collider.gameObject.GetComponent<DamageReceiver>().TakeDamage(damageAmount);
            }
            ExpireBullet();
        }
    }

    private void ExpireBullet()
    {
        collisionActive = false;
        Destroy(gameObject,expireTime);
        if(mySpriteRenderer)
        {
            //
        }
    }
}
