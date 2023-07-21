using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider bossBar;
    public BossHealth bossHealth;

    private void Start()
    {
        bossBar.maxValue = bossHealth.maxHealth;
        bossBar.value = bossHealth.curHealth;
    }

    public void SetHealth(int hp)
    {
        bossBar.value = hp;
    }
}
