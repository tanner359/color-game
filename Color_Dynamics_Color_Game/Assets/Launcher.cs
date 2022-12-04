using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Launcher
{
    public static void Reload_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Load_Scene()
    {

    }
}
