using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    Inputs inputs;
    Vector2 moveDir;
    Rigidbody2D rb;

    //Movement Settings
    public float moveSpeed = 1.0f;

    private void Awake()
    {
        if(inputs == null)
        {
            inputs = new Inputs();
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        inputs.Player.Move.performed += Move;
        inputs.Player.Move.canceled += Move;
        inputs.Player.Enable();
    }

    private void FixedUpdate()
    {
        if(moveDir != Vector2.zero)
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
