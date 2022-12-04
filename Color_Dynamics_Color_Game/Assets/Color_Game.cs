using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Game : MonoBehaviour
{
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
    public void Next_Game()
    {
        if(Game != Game_Mode.After_Image)
        {
            Game += 1;
            return;
        }
        Debug.Log("The End - Thanks For Playing!");
    }
}

