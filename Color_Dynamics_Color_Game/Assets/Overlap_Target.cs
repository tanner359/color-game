using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Overlap_Target : MonoBehaviour
{
    public Overlap_Door[] path;
    public Color playerColor;

    public Image img;


    private void Awake()
    {
        playerColor = FindObjectOfType<Player>().Player_Color;
    }

    private void Start()
    {
        StartCoroutine(Set_Color());
    }

    private IEnumerator Set_Color()
    {
        yield return new WaitForEndOfFrame();
        img.color = Calculate_Target();
    }

    private Color Calculate_Target()
    {
        Color result = playerColor;

        foreach(Overlap_Door d in path)
        {
            result = Color_Game.Get_Overlap(d.sr.color, result, false);
        }

        return result;
    }

}
