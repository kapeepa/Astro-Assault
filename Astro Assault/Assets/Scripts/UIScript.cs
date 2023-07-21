using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject levelCompleteScreen;
    public GameObject pauseScreen;
    public GameObject deathScreen;

    public PlayerScript playerScript;

    private void Awake()
    {
        levelCompleteScreen.SetActive(false);
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
    }

    public void EnableLvlComplete()
    {
        levelCompleteScreen.SetActive(true);
        playerScript.DisablePlayer();
    }

    public void EnablePauseScreen()
    {
        pauseScreen.SetActive(true);
        playerScript.DisablePlayer();
    }

    public void DisablePauseScreen()
    {
        pauseScreen.SetActive(false);
        playerScript.EnablePlayer();
    }

    public void EnableDeathScreen()
    {
        deathScreen.SetActive(true);
        playerScript.DisablePlayer();
    }
}
