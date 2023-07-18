using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public PlayerHealth playerHealth;

    private void Start()
    {
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.curHealth;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
