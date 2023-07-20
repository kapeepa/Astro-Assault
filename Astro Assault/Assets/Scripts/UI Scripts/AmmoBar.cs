using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour
{
    public GameObject bar1, bar2, bar3, bar4, bar5;

    private void Awake()
    {
        bar1.SetActive(true);
        bar2.SetActive(true);
        bar3.SetActive(true);
        bar4.SetActive(true);
        bar5.SetActive(true);
    }

    public void disableBars()
    {
        if (!bar5.activeSelf && bar4.activeSelf)
        {
            bar4.SetActive(false);
        }
        else if (!bar4.activeSelf && bar3.activeSelf)
        {
            bar3.SetActive(false);
        }
        else if (!bar3.activeSelf && bar2.activeSelf)
        {
            bar2.SetActive(false);
        }
        else if (!bar2.activeSelf && bar1.activeSelf)
        {
            bar1.SetActive(false);
        }
        else if (bar5.activeSelf)
        {
            bar5.SetActive(false);
        }
    }
}
