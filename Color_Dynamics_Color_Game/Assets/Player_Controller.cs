using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : Color_Game
{
    Inputs inputs;
    public Vector2 moveDir;
    public Rigidbody2D rb;
    public Animator animator;

    //Movement Settings
    public float moveSpeed = 1.0f;

    private void Awake()
    {
        if(inputs == null)
        {
            inputs = new Inputs();
        }
    }

    private void Lock_Controller()
    {
        Debug.Log("locked");
        inputs.Player.Move.Disable();
        animator.applyRootMotion = false;
    }

    private void Unlock_Controller()
    {
        Debug.Log("unlocked");
        inputs.Player.Move.Enable();
        animator.applyRootMotion = true;
    }

    private void OnEnable()
    {
        inputs.Player.Move.performed += Move;
        inputs.Player.Move.canceled += Move;
    }

    private void FixedUpdate()
    {
        if (moveDir != Vector2.zero)
        {
            Vector2 d = (Vector2)transform.position + (moveSpeed * moveDir) * Time.deltaTime;
            rb.MovePosition(d);
        }
    }

    private void Move(InputAction.CallbackContext obj)
    {
        moveDir = obj.ReadValue<Vector2>();  
    }
}
