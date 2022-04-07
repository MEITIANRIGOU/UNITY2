using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public float movementSpeed;
    public float cameraSpeed;

    protected Vector3 processedInput = new Vector3(0, 0, 0);
    protected float mouseInputX;
    protected float mouseInputY;
    protected float horizontalInput;
    protected float verticalInput;

    protected bool canJump = false;

    protected Rigidbody rb;
    protected Animator anim;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update()
    {
        processedInput = (transform.forward * verticalInput + transform.right * horizontalInput);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            anim.SetBool("Moving", true);

            if (verticalInput > 0)
            {
                anim.SetBool("Forward", true);
                anim.SetBool("Backward", false);
            }
            else if (verticalInput < 0)
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Backward", true);
            }
            else if (verticalInput == 0)
            {
                anim.SetBool("Forward", false);
                anim.SetBool("Backward", false);
            }

            if (horizontalInput > 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", true);
            }
            else if (horizontalInput < 0)
            {
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);
            }
            else if (horizontalInput == 0)
            {
                anim.SetBool("Left", false);
                anim.SetBool("Right", false);
            }
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

    protected void FixedUpdate()
    {
        rb.MovePosition(transform.position + (processedInput.normalized * movementSpeed * Time.deltaTime));

        transform.Rotate(new Vector3(0, mouseInputX, 0) * cameraSpeed, Space.Self);
        transform.GetChild(4).transform.Rotate(new Vector3(-mouseInputY, 0, 0) * cameraSpeed, Space.Self);

        if (CheckAngle(transform.GetChild(4).transform.localEulerAngles.x) < -60)
        {
            transform.GetChild(4).transform.localEulerAngles = new Vector3(-60, 0, 0);
        }
        if (CheckAngle(transform.GetChild(4).transform.localEulerAngles.x) > 60)
        {
            transform.GetChild(4).transform.localEulerAngles = new Vector3(60, 0, 0);
        }
    }
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            anim.SetBool("Jumping", false);
        }
    }
    protected void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = true;
        }
    }
    protected void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = false;
        }
    }
    public float CheckAngle(float Value)
    {
        float Angle = Value - 180;
        if (Angle > 0)
        {
            return Angle - 180;
        }
        return Angle + 180;
    }
}