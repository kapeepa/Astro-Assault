using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MoveEvent : UnityEvent <float> { }

public class PlayerScript : MonoBehaviour
{
    public MoveEvent ForwardBackMove;
    public MoveEvent LeftRightMove;
    public UnityEvent onJumpPressed;
    public UnityEvent onFirePressed;
    public UnityEvent onTeleportPressed;

    private void Start()
    {
        GetComponent<PlayerScript>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetButton("Vertical"))
            ForwardBackMove.Invoke(Input.GetAxis("Vertical"));
        if (Input.GetButton("Horizontal"))
            LeftRightMove.Invoke(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            onJumpPressed.Invoke();
        if (Input.GetButtonDown("Fire1"))
            onFirePressed.Invoke();
        if (Input.GetButtonDown("Fire2"))
            onTeleportPressed.Invoke();
    }

    public void Die()
    {
        GetComponent<PlayerScript>().enabled = false;
    }
}
