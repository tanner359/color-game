using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Game : MonoBehaviour
{
    public static bool[] unlocked = {true,false,false};
    public enum Game_Mode { Complementary, Overlaping, After_Image}
    public Game_Mode Game = Game_Mode.Complementary;

    public bool Is_Complementary(Color a, Color b)
    {
        b.r = (int)(b.r * 10)/10f;
        b.g = (int)(b.g * 10)/10f;
        b.b = (int)(b.b * 10)/10f;
        Color test = Color.white - a + Color.black;
        if (Color.white - a + Color.black == b)
        {
            return true;
        }
        return false;
    }
    public Color Get_Complementary(Color a)
    {
        return Color.white - a + Color.black;
    }

    public Color Get_Overlap(Color x, Color y, bool reverse)
    {
        float r, g, b, a;
        if (!reverse){
            r = (x.r + y.r) / 2f;
            g = (x.g + y.g) / 2f;
            b = (x.b + y.b) / 2f;
            a = 1.0f;
            print("Forward: " + new Color(r, g, b, a));
            return new Color(r, g, b, a);
        }

        r = ((y.r - x.r) * 2f) + x.r;
        g = ((y.g - x.g) * 2f) + x.g;
        b = ((y.b - x.b) * 2f) + x.b;
        a = 1.0f;
        print("Back: " + new Color(r, g, b, a));
        return new Color(r, g, b, a);
    }

    public void Change_Game_Mode(Game_Mode mode)
    {
        Game = mode;
    }

    public void Load_Level(int i)
    {
        Launcher.Load_Scene(i);
    }
}

