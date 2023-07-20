using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportBar : MonoBehaviour
{
    public GameObject bar1, bar2;

    private void Awake()
    {
        bar1.SetActive(true);
        bar2.SetActive(true);
    }

    public void disableBars()
    {
        if (!bar2.activeSelf)
        {
            bar1.gameObject.SetActive(false);
        }
        bar2.gameObject.SetActive(false);
    }
}