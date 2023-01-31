using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

public class CharacterMovement : MonoBehaviour
{

    //-----Editable Variables-----//
    [Header("MovementStats")] 
    [SerializeField] private float speed;
    
    
    
    //-----Privates Variables-----//
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        
        movement = InputManager.instance.move.ReadValue<Vector2>(); //Reading the value of the input to get the direction

        if (movement == Vector2.zero)
        {
            anim.SetBool("isWalking", false);
            rb.velocity = Vector3.zero;
        }
        else
        {
            anim.SetBool("isWalking", true);
            rb.velocity = movement.normalized * speed;
        }
            
            
    }
    
}
