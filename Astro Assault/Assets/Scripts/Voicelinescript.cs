using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Voicelinescript : MonoBehaviour
{
    public AudioSource source;

    private void Awake()
    {
        this.GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.Play();
            this.GetComponent<Collider>().enabled = false;
        }
    }

}

