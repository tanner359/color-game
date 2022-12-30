using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Volume : Action_Volume_2D
{
    public UnityEvent OnTrigger;

    private void Awake()
    {
        action += Trigger;
    }

    public void Trigger(GameObject actor)
    {
        OnTrigger.Invoke();
        enabled = false;
    }

}
