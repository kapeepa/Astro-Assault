using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DialogueScript : MonoBehaviour
{
    public AudioSource[] sources;
    private float time;

    private void Start()
    {
        time = 0;
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].PlayDelayed(time);
            time += sources[i].clip.length;
        }
    }
}
