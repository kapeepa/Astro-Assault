using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportBar : MonoBehaviour
{
    public GameObject bar1, bar2;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        bar1.SetActive(true);
        bar2.SetActive(true);
    }

    public void RefreshBars()
    {
        switch (playerMovement.teleportCount)
        {
            case 2:
                bar2.SetActive(true);
                bar1.SetActive(true);
                break;
            case 1:
                bar2.SetActive(false);
                bar1.SetActive(true);
                break;
            case 0:
                bar2.SetActive(false);
                bar1.SetActive(false);
                break;
        }

    }
}
