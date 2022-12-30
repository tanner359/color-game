using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_Door : Door
{
    public int level;
    public UnityEvent OnUnlocked;

    new private void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        if (Color_Game.unlocked[level - 1] == true)
        {
            OnUnlocked.Invoke();
        }
    }
}
