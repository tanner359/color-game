using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    Inputs inputs;
    Vector3 moveDir;

    private void Awake()
    {
        if(inputs == null)
        {
            inputs = new Inputs();
        }
    }

    private void OnEnable()
    {
        inputs.Player.Move.performed += Move;
        inputs.Player.Move.canceled += Move;
        inputs.Player.Enable();
    }

    private void Update()
    {
        if(moveDir != Vector3.zero)
        {

        }
    }

    private void Move(InputAction.CallbackContext obj)
    {
        
    }
}
