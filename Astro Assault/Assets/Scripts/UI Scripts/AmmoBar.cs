using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public GameObject bar1, bar2, bar3, bar4, bar5;
    public ShooterScript shooter;

    private void Awake()
    {
        bar1.SetActive(true);
        bar2.SetActive(true);
        bar3.SetActive(true);
        bar4.SetActive(true);
        bar5.SetActive(true);
    }

    public void RefreshBars()
    {
        switch (shooter.ammoCount)
        {
            case 5:
                bar1.SetActive(true);
                bar2.SetActive(true);
                bar3.SetActive(true);
                bar4.SetActive(true);
                bar5.SetActive(true);
                break;
            case 4:
                bar1.SetActive(true);
                bar2.SetActive(true);
                bar3.SetActive(true);
                bar4.SetActive(true);
                bar5.SetActive(false);
                break;
            case 3:
                bar1.SetActive(true);
                bar2.SetActive(true);
                bar3.SetActive(true);
                bar4.SetActive(false);
                bar5.SetActive(false);
                break;
            case 2:
                bar1.SetActive(true);
                bar2.SetActive(true);
                bar3.SetActive(false);
                bar4.SetActive(false);
                bar5.SetActive(false);
                break;
            case 1:
                bar1.SetActive(true);
                bar2.SetActive(false);
                bar3.SetActive(false);
                bar4.SetActive(false);
                bar5.SetActive(false);
                break;
            case 0:
                bar1.SetActive(false);
                bar2.SetActive(false);
                bar3.SetActive(false);
                bar4.SetActive(false);
                bar5.SetActive(false);
                break;
        }
    }
}
