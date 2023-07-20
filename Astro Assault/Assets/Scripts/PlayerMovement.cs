using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    float speed = 10;
    int jumpCount;
    public int teleportCount;
    Rigidbody rb;
    public AudioClip teleportClip;
    public AudioClip jumpClip;

    private bool facingLeft = false;
    Vector3 leftRotation = new Vector3(0, -90, 0);
    private bool facingRight = false;
    Vector3 rightRotation = new Vector3(0, 90, 0);
    private bool facingForward = true;
    Vector3 forwardRotation = new Vector3(0, 0, 0);
    private bool facingBack = false;
    Vector3 backRotation = new Vector3(0, 180, 0);

    private void Awake()
    {
        ResetJump();
        ResetTeleport();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveForwardBack(float axis)
    {
        if (axis > 0 && !facingForward)
        {
            transform.eulerAngles = forwardRotation;
            facingLeft = false;
            facingRight = false;
            facingForward = true;
            facingBack = false;
        }
        else if (axis < 0 && !facingBack)
        {
            transform.eulerAngles = backRotation;
            facingLeft = false;
            facingRight = false;
            facingForward = false;
            facingBack = true;
        }

        transform.Translate(0, 0, speed * Time.deltaTime * axis, Space.World);
    }

    public void MoveLeftRight(float axis)
    {
        if (axis > 0 && !facingRight)
        {
            transform.eulerAngles = rightRotation;
            facingLeft = false;
            facingRight = true;
            facingForward = false;
            facingBack = false;
        }
        else if (axis < 0 && !facingLeft)
        {
            transform.eulerAngles = leftRotation;
            facingLeft = true;
            facingRight = false;
            facingForward = false;
            facingBack = false;
        }

        transform.Translate(speed * Time.deltaTime * axis, 0, 0, Space.World);
    }

    //fed clip from OnFootstep animation event
    public void OnFootstep(AudioClip clip)
    {
        AudioManager.Instance.PlaySFX(clip);
    }

    public void Jump()
    {
        if(jumpCount > 0)
        {
            rb.AddForce(0, 20, 0, ForceMode.Impulse);
            jumpCount--;
            AudioManager.Instance.PlaySFX(jumpClip);
        }
    }

    public void ResetJump()
    {
        jumpCount = 1;
    }

    public void ResetTeleport()
    {
        teleportCount = 2;
    }

    public void Teleport()
    {
        if (teleportCount > 0)
        {
            AudioManager.Instance.PlaySFX(teleportClip);
            if (facingLeft) transform.Translate(-10, 0, 0, Space.World);
            if (facingRight) transform.Translate(10, 0, 0, Space.World);
            if (facingForward) transform.Translate(0, 0, 10, Space.World);
            if (facingBack) transform.Translate(0, 0, -10, Space.World);
        }

        teleportCount--;

    }
}
