using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : Action_Volume_2D
{
    public UnityEvent Signals;


    public void Awake()
    {
        action += Queue_Load;
    }

    public void Queue_Load(GameObject actor)
    {
        print("teleport");

        Signals.Invoke();
    }
}
