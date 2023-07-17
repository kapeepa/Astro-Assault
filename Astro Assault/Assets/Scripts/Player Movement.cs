using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [Range(1, 100)] float speed;
    int currentJumps;
    Rigidbody rb;

    void Start()
    {
        currentJumps = 0;
        rb = GetComponent<Rigidbody>();
    }

    public void MoveForwBack(float axis)
    {
        transform.Translate(speed * Time.deltaTime * axis, 0, 0);
    }

    public void MoveLeftRight(float axis)
    {
        transform.Translate(0, 0, speed * Time.deltaTime * axis);
    }

    public void Jump()
    {
        if(currentJumps < 1)
        {
            rb.AddForce(0, 0.8f, 0, ForceMode.Impulse);
            currentJumps++;
        }
    }

    public void ResetJump()
    {
        currentJumps = 0;
    }
}
