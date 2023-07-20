using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Voicelinescript : MonoBehaviour
{
    public UnityEvent OnCollide;
    public AudioSource audiosource;
    public new Component collider;
    private void OnCollisionEnter(Collision collision)
    {
        audiosource.Play();
        Destroy(collider);
    }

}

