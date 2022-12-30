using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_UI : MonoBehaviour
{
    public List<Menu> menus;

    public void Open_Menu(string id)
    {
        Menu target = null;
        foreach(Menu m in menus)
        {
            if(m.menuID == id)
            {
                target = m;
                continue;
            }
            m.gameObject.SetActive(false);
        }
        target.gameObject.SetActive(true);
    }

    public void Close_Menu(string id)
    {
        foreach (Menu m in menus)
        {
            if (m.menuID == id)
            {
                if(m.FX != null)
                {
                    m.FX.SetTrigger("Close");
                }
            }
        }
    }

    public void Close_Menu_All()
    {
        foreach (Menu m in menus)
        {
            m.gameObject.SetActive(false);
        }
    }
}
