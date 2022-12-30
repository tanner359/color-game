using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public string menuID;
    public Animator FX;

    public void Reload()
    {
        Launcher.Reload_Scene();
    }

    public void Load_Level(int i)
    {
        Launcher.Load_Scene(i);
    }

    public void Disable_Menu()
    {
        gameObject.SetActive(false);  
    }
}
