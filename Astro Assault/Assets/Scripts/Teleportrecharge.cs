using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleportrecharge : MonoBehaviour
{
    GameObject player;
    
    private void OnCollisionEnter(Collision collision)
    {
        player.GetComponent<PlayerMovement>().ResetTeleport();
        if (collision.gameObject.CompareTag("Player"))
         {
            
            
         }
    }
}
