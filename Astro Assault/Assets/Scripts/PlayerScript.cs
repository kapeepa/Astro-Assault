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

    public Animator animator;

    private void Start()
    {
        GetComponent<PlayerScript>().enabled = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButton("Vertical"))
        {
            animator.SetBool("isRun", true);
            ForwardBackMove.Invoke(Input.GetAxis("Vertical"));
        }

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("isRun", true);
            LeftRightMove.Invoke(Input.GetAxis("Horizontal"));
        }

        if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
            animator.SetBool("isRun", false);

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJump", true);
            onJumpPressed.Invoke();
            animator.SetBool("isGrounded", false);
        }

        if (Input.GetButtonDown("Fire1"))
            onFirePressed.Invoke();
        if (Input.GetButtonDown("Fire2"))
            onTeleportPressed.Invoke();
    }

    public void Die()
    {
        GetComponent<PlayerScript>().enabled = false;
    }

    public void ResetGrounded()
    {
        animator.SetBool("isGrounded", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJump", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", false);
        }
    }

}
