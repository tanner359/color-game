using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Color_Game
{
    public Player_UI UI;
    public Animator animator;

    public Color m_player_color;
    public Color Player_Color { get { return m_player_color; } set { m_player_color = value; GetComponent<SpriteRenderer>().color = value; } }

    public int points;
    public int Points { get { return points; } set { points = value; UI.points.text = "Points: " + value.ToString(); UI.final_score.text = points.ToString(); } }

    public int life_points;
    public int Life { get { return life_points; } set { life_points = value; UI.life_points.text = "Lives: " + value.ToString(); } }

    public int m_longest_streak;
    public int Longest_Streak { get { return m_longest_streak;  } set { m_longest_streak = value; UI.longest_streak.text = value.ToString(); } }

    public int m_current_streak;
    public int Current_Streak { get { return m_current_streak; } set { m_current_streak = value; if(value > Longest_Streak) { Longest_Streak = value; } } }

    public bool dead;


    public GameObject death_particle;


    private void Start()
    {
        if(Game == Game_Mode.Complementary)
        {
            StartCoroutine(Color_Cycle());
        }
    }

    public void Damage_Self()
    {
        Current_Streak = 0;
        Life -= 1;
        dead = Life == 0;
        if (dead)
        {
            Destroy(gameObject);
            Instantiate(death_particle, transform.position, Quaternion.identity);
            UI.Open_Menu("Chapter_01_Complete");
        }     
    }

    public IEnumerator Color_Cycle()
    {
        while (!dead)
        {
            int r = Random.Range(0, 10);
            int g = Random.Range(0, 10);
            int b = Random.Range(0, 10);
            Player_Color = new Color(r/10f, g/10f, b/10f, 1.0f);
            yield return new WaitForSeconds(10f);    
        }
    }
}
