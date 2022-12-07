using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public string menuID;
    public Animator FX;
    Inputs input;

    private void OnEnable()
    {
        if(input == null)
        {
            input = new Inputs();
        }
        input.Player.Continue.performed += Continue;
        input.Player.Continue.Enable();
    }

    private void Continue(InputAction.CallbackContext obj)
    {
        if (Color_Game.unlocked[1])
        {
            Launcher.Load_Scene(3);
            return;
        }
        Launcher.Reload_Scene();
    }

    public void Disable_Menu()
    {
        gameObject.SetActive(false);  
    }

    private void OnDisable()
    {
        input.Player.Continue.Disable();
    }
}
