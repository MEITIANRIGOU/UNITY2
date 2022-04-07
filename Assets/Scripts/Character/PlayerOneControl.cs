using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControl : MovementControl
{
    public GameObject punch;
    public GameObject missle;
    protected override void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");//×óÓÒ£¬×ó-1£¬ÓÒ1
        verticalInput = Input.GetAxisRaw("Vertical");//Ç°ºó

        mouseInputX = Input.GetAxisRaw("Mouse X");
        mouseInputY = Input.GetAxisRaw("Mouse Y");

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Jumping", true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject spawnedMissle = Instantiate(missle, transform.GetChild(4).transform.position, transform.rotation);
            spawnedMissle.GetComponent<Missle>().playerID = 1;
            spawnedMissle.GetComponent<Rigidbody>().velocity = transform.forward * 100;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject spawnedPunch = Instantiate(punch, transform);
            spawnedPunch.GetComponent<Punch>().playerID = 1;
        }

        base.Update();
    }
}
