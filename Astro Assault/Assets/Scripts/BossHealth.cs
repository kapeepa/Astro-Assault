using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public BossHealthBar healthBar;
    public BossScript bossScript;

    public AudioClip damageClip;
    public AudioClip endClip;

    private void Awake()
    {
        curHealth = maxHealth;
    }

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void DamageBoss(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        if (curHealth > 0) AudioManager.Instance.PlayOneShots(damageClip);
        else if (curHealth <= 0) AudioManager.Instance.PlayOneShots(endClip);
    }

    private void Update()
    {
        if (curHealth <= 0)
        {
            bossScript.InvokeEndTimes();
        }
    }
}
