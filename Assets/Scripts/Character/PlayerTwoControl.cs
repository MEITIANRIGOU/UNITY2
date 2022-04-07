using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControl : MovementControl
{
    public GameObject punch;
    public GameObject missle;
    protected override void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal Joystick");//���ң���-1����1
        verticalInput = Input.GetAxisRaw("Vertical Joystick");//ǰ��

        mouseInputX = Input.GetAxisRaw("Camera Joystick X");
        mouseInputY = Input.GetAxisRaw("Camera Joystick Y");

        if (canJump && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Jumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            GameObject spawnedMissle = Instantiate(missle, transform.GetChild(4).transform.position, transform.rotation);
            spawnedMissle.GetComponent<Missle>().playerID = 2;
            spawnedMissle.GetComponent<Rigidbody>().velocity = transform.forward * 100;
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            GameObject spawnedPunch = Instantiate(punch, transform);
            spawnedPunch.GetComponent<Punch>().playerID = 2;
        }

        base.Update();
    }
}