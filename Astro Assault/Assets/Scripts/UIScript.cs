using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject levelCompleteScreen;
    public GameObject pauseScreen;

    public PlayerScript playerScript;
    public bool paused;

    private void Awake()
    {
        levelCompleteScreen.SetActive(false);
        pauseScreen.SetActive(false);
        paused = false;
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
}
