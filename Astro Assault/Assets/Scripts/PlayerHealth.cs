using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public PlayerScript playerScript;
    public GameManager gameManager;

    public AudioClip damageClip;

    private void Awake()
    {
        curHealth = maxHealth;
    }

    private void Start()
    {
        curHealth = maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
        if(curHealth > 0) AudioManager.Instance.PlaySFX(damageClip);
    }

    private void Update()
    {
        if (curHealth <= 0)
        {
            playerScript.DisablePlayer();
            gameManager.GameOver();
        }
    }
}
