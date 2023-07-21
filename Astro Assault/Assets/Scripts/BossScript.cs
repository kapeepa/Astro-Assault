using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossScript : MonoBehaviour
{
    public GameObject laser;
    public GameObject[] spots;
    public AudioClip fireClip;
    public AudioClip teleClip;
    public AudioClip bossMusic;

    public UnityEvent endTimes;
    public GameObject winScreen;

    public DialogueScript DiaScript;
    bool dialogueDone, coroutineStarted;

    private void Start()
    {
        dialogueDone = false;
        coroutineStarted = false;
        winScreen.SetActive(false);
        GetComponent<BossScript>().enabled = true;
    }

    IEnumerator Cycle()
    {
        coroutineStarted = true;
        while (dialogueDone)
        {
            for (int i = 0; i < spots.Length; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Fire();
                    yield return new WaitForSeconds(Random.Range(0.5f, 0.75f));
                }
                for (int j = 0; j < 45; j++)
                {
                    Fire();
                    transform.Rotate(new Vector3(0, 8, 0));
                    yield return new WaitForSeconds(0.05f);
                }

                yield return new WaitForSeconds(8);

                transform.SetPositionAndRotation(spots[i].transform.position, spots[i].transform.rotation);
                AudioManager.Instance.PlayOneShots(teleClip);
            }
        }
    }

    private void Update()
    {
        if (!dialogueDone)
        {
            int counter = 0;
            for (int i = 1; i <= DiaScript.sources.Length; i++)
            {
                if (DiaScript.sources[i-1].isPlaying) dialogueDone = false;
                else counter++;
            }
            if (counter == DiaScript.sources.Length) dialogueDone = true;
        }

        if(dialogueDone && !coroutineStarted)
        {
            StartCoroutine("Cycle");
            AudioManager.Instance.PlayMusic(bossMusic);
            AudioManager.Instance.MusicSource.loop = true;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    void Fire()
    {
        Instantiate(laser, this.transform.position, this.transform.rotation);
        AudioManager.Instance.PlaySFX(fireClip);
    }

    public void InvokeEndTimes()
    {
        endTimes.Invoke();
    }

    public void DisableBoss()
    {
        StopAllCoroutines();
        GetComponent<BossScript>().enabled = false;
        AudioManager.Instance.MusicSource.loop = false;
        AudioManager.Instance.MusicSource.Stop();
    }

    public void EnableWinScreen()
    {
        winScreen.SetActive(true);
    }
}
