﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonMovement : MonoBehaviour
{
    private const float DOUBLE_CLICK_TIME = .2f;
    public CharacterController controller;

    public Transform cam;

    public float DashSpeed = 1000;
    public float speed = 6f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundmask;

    public float turnSmoothTime = 0.1f;
    float turnsmoothvel;
    Vector3 velocity;
    public bool isGrounded;
    private Vector3 moveDir;

    public ParticleSystem dashParticals;

    private float lastClickTime;

    public float aimRadius = 100f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
            
        }

        velocity.y += gravity * Time.deltaTime;
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        //movement
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        //dash
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            //dash
            //controller.Move(moveDir.normalized * DashSpeed * Time.deltaTime);
            //dashParticals.Emit(100);
            //Collider[] colliders = Physics.OverlapSphere(transform.position, aimRadius);

            //foreach (Collider pushedObjec in colliders)
            //{
            //    if (pushedObjec.CompareTag("Enemy"))
            //    {
            //        transform.LookAt(pushedObjec.gameObject.transform, Vector3.forward);
            //    }
            //}
            

        }


        

        controller.Move(velocity * Time.deltaTime);

    }
}



//if (direction.magnitude >= 0.1f)
//{
//    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
//    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvel, turnSmoothTime);
//    transform.rotation = Quaternion.Euler(0f, angle, 0f);

//    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
//    controller.Move(moveDir.normalized * speed * Time.deltaTime);

//}


//double click
//if (Input.GetKeyDown(KeyCode.W))
//{

//    float timesinceLastClick = Time.time - lastClickTime;

//    if (timesinceLastClick <= DOUBLE_CLICK_TIME)
//    {
//        //double click
//        Debug.Log("press twice");

//    }

//    else
//    {
//        //normal click
//        Debug.Log("press once");
//    }

//    lastClickTime = Time.time;
//}
