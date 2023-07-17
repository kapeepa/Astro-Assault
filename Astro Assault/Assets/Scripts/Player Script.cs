using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MoveEvent : UnityEvent <float> { }

public class PlayerScript : MonoBehaviour
{
    public PlayerScript Player;

    public MoveEvent ForwBackMove;
    public MoveEvent LeftRightMove;
    public UnityEvent onJumpPressed;
    public UnityEvent onFirePressed;
    public UnityEvent onTeleportPressed;

    private int maxHealth = 3;
    public int currentHealth;

    //Make player character persist through scenes
    private void Awake()
    {
        Player = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        GetComponent<PlayerScript>().enabled = true;
    }

    private void Update()
    {
        if (Input.GetButton("Vertical"))
            ForwBackMove.Invoke(Input.GetAxis("Vertical"));
        if (Input.GetButton("Horizontal"))
            LeftRightMove.Invoke(Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
            onJumpPressed.Invoke();
        if (Input.GetButtonDown("Fire1"))
            onFirePressed.Invoke();
        if (Input.GetButtonDown("Fire2"))
            onTeleportPressed.Invoke();
    }


}
