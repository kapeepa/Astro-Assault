using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public UnityEvent Interaction;
    public GameObject interactionText;

    float detectionRange = 5;
    public PlayerScript player;

    private void Start()
    {
        interactionText.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= detectionRange)
        {
            if (!interactionText.activeSelf) interactionText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                Interaction.Invoke();
            }
        }
        else if (interactionText.activeSelf) interactionText.SetActive(false);


    }
}
