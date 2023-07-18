using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int curHealth;
    public int maxHealth = 100;
    public HealthBar healthBar;
    public PlayerScript playerScript;

    private void OnEnable()
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
    }

    private void Update()
    {
        if (curHealth <= 0)
        {
            playerScript.Die();
            GameManager.Instance.GameOver();
        }
    }
}
