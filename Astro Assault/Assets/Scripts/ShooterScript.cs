using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooterScript : MonoBehaviour
{
    public UnityEvent onShoot;
    public GameObject laser;
    public AudioClip fireClip;

    public bool canShoot = true;
    float timeBetweenShots = 0.75f;
    private float timeUntilNextShot;
    public int ammoCount;

    private void Start()
    {
        ResetAmmo();
    }

    void Update()
    {
        if(Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
    }

    public void Shoot()
    {
        onShoot.Invoke();
    }

    public void Fire()
    {
        if (ammoCount > 0)
        {
            AudioManager.Instance.PlaySFX(fireClip);
            Instantiate(laser, this.transform.position, this.transform.rotation);
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShots;
            ammoCount--;
        }
    }

    public void ResetAmmo()
    {
        ammoCount = 5;
    }
}
