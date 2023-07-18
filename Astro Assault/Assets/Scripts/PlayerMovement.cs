using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [Range(1, 100)] public float speed;
    int currentJumps;
    int currentTeleports;
    Rigidbody rb;


    private bool facingLeft;
    Vector3 leftRotation = new Vector3(0, -90, 0);
    private bool facingRight;
    Vector3 rightRotation = new Vector3(0, 90, 0);
    private bool facingForward;
    Vector3 forwardRotation = new Vector3(0, 0, 0);
    private bool facingBack;
    Vector3 backRotation = new Vector3(0, 180, 0);

    void Start()
    {
        currentJumps = 0;
        currentTeleports = 0;
        rb = GetComponent<Rigidbody>();

        facingLeft = false;
        facingRight = false;
        facingForward = true;
        facingBack = false;
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

    public void Jump()
    {
        if(currentJumps < 1)
        {
            rb.AddForce(0, 20, 0, ForceMode.Impulse);
            currentJumps++;
        }
    }

    public void ResetJump()
    {
        currentJumps = 0;
    }

    public void Teleport()
    {
        if (currentTeleports < 2)
        {
            if (facingLeft) transform.Translate(-3, 0, 0, Space.World);
            if (facingRight) transform.Translate(3, 0, 0, Space.World);
            if (facingForward) transform.Translate(0, 0, 3, Space.World);
            if (facingBack) transform.Translate(0, 0, -3, Space.World);
        }

        currentTeleports++;

    }
}
