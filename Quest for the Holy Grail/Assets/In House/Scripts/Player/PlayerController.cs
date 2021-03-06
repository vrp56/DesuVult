﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private CharacterController controller;

    [Header("Kinematics")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 2f;
    private float airTimer;
    [SerializeField] private float airTimeThreshold = .5f;
    private Vector3 velocity;
    private float tempSlopeLimit;
    private float tempStepOffset;
    private Vector2 impulse;
    public bool isGrounded = false;
    public bool instantIsGrounded = false;

    [Header("Stats")]
    [SerializeField] private Health health;




    void Start()
    {
        tempSlopeLimit = controller.slopeLimit;
        tempStepOffset = controller.stepOffset;
        EventManager.PlayerDamaged += onDamaged;
    }

    void OnDisable()
    {
        EventManager.PlayerDamaged -= onDamaged;
    }

    void Update()
    {

        handleMove();
        handleJump();
        handleGravity();


        smoothGroundCheck();
        groundCheck();

        //If you land on the ground, don't accumulate negative velocity
        //OR
        //If you bump your head, lose upward velocity
        if ((groundCheck() && velocity.y < 0) || ((controller.collisionFlags & CollisionFlags.Above) != 0))
        {

            //reset our parameters
            controller.slopeLimit = tempSlopeLimit;
            controller.stepOffset = tempStepOffset;


            velocity.y = 0f;
        }
    }


    bool smoothGroundCheck()
    {
        if (!groundCheck())
        {
            airTimer += Time.deltaTime;
        }
        else
        {
            airTimer = 0f;
        }
        if (airTimer > airTimeThreshold)
        {
            isGrounded = false;
            return false;
        }
        isGrounded = true;
        return true;
    }

    bool groundCheck()
    {
        if ((controller.collisionFlags & CollisionFlags.Below) != 0)
        {
            instantIsGrounded = true;
            return true;
        }
        instantIsGrounded = false;
        return false;
    }

    void handleJump()
    {
        if (Input.GetButtonDown("Jump") && smoothGroundCheck())
        {

            //this block helps prevent the player from getting stuck on walls
            tempSlopeLimit = controller.slopeLimit;
            controller.slopeLimit = 90f;
            tempStepOffset = controller.stepOffset;
            controller.stepOffset = .1f;


            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            // smoothedIsGrounded = false;
            airTimer = airTimeThreshold * 2;
        }
    }

    void handleMove()
    {
        impulse.x = Input.GetAxisRaw("Horizontal");
        impulse.y = Input.GetAxisRaw("Vertical");
        impulse.Normalize();


        Vector3 move = transform.right * impulse.x + transform.forward * impulse.y;

        controller.Move(Vector3.ClampMagnitude(move, 1f) * speed * Time.deltaTime);
    }

    void handleGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void onDamaged(float damage)
    {
        health.damage(damage);
    }
}
