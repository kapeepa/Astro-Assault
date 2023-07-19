using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    public GameObject player;
    public GameObject playercamera;
    void Update()
    {
        playercamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15, player.transform.position.z - 20);
    }
}
