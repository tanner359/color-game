using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Trigger : Color_Game
{
    Player player;
    Color prevColor;
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(player.Player_Color != prevColor)
        {
            Set_Complementary(player.Player_Color);
            prevColor = player.Player_Color;
        }
    }

    public void Set_Complementary(Color c)
    {
        ParticleSystem.MainModule main = ps.main;

        Gradient newGradient = new Gradient();

        newGradient.mode = GradientMode.Fixed;

        int r = Random.Range(1, 10);
        int g = Random.Range(1, 10);
        while (Mathf.Abs(r - g) < 1f)
        {
            g = Random.Range(1, 10);
        }
        int b = Random.Range(1, 10);
        while (Mathf.Abs(b - g) < 1f)
        {
            b = Random.Range(1, 10);
        }

        GradientColorKey key0 = new GradientColorKey(new Color(r/10,g/10,b/10,1.0f), 1.0f);
        GradientColorKey key1 = new GradientColorKey(Get_Complementary(c), 0.5f);
        GradientColorKey[] c_keys = { key0, key1 };

        GradientAlphaKey a_key0 = new GradientAlphaKey(1f, 0f);
        GradientAlphaKey a_key1 = new GradientAlphaKey(1f, 1f);
        GradientAlphaKey[] a_keys = { a_key0, a_key1 };

        newGradient.SetKeys(c_keys, a_keys);

        main.startColor = newGradient;
    }

    private void OnParticleTrigger()
    {
        if(ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter) > 0)
        {
            if (!Is_Complementary(player.Player_Color, enter[0].GetCurrentColor(ps)))
            {
                player.Damage_Self();
                ps.TriggerSubEmitter(1, enter);
                ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
                return;
            }
            ps.TriggerSubEmitter(0, enter);
            ps.SetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
            player.Points += 10;
            player.Current_Streak += 1;
        }    
    }
}
