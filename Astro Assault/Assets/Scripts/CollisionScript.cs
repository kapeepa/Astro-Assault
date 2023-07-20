using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class CollisionScript : MonoBehaviour
{
    public UnityEvent onCollide;
    public UnityEvent onGroundCollide;
    public UnityEvent onHazardCollide;
    public UnityEvent onPlayerCollide;

    public UnityEvent onTrigger;
    public UnityEvent onLaserTrigger;

    public AudioClip landClip;
    float firstTime;

    private void Start()
    {
        firstTime = Time.time + 1.5f;
    }

    private void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "Hazard":
                onHazardCollide.Invoke();
                break;
            case "Ground":
                onGroundCollide.Invoke();
                if (Time.time > firstTime) AudioManager.Instance.PlaySFX(landClip);
                break;
            case "Player":
                onPlayerCollide.Invoke();
                break;
            default:
                onCollide.Invoke();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        switch (tag)
        {
            case "Laser":
                onLaserTrigger.Invoke();
                break;
            default:
                if (tag != "Player")
                {
                    onTrigger.Invoke();
                }
                break;
        }
    }

    public void DestroyObject(float timeAfter)
    {
        Destroy(this.gameObject, timeAfter);
    }


}
