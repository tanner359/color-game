using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Trigger : MonoBehaviour
{
    Player player;
    public int complementary_value;
    ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        player = FindObjectOfType<Player>();
    }

    private void OnParticleTrigger()
    {
        if(ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter) > 0)
        {
            if (player.complementary_value != this.complementary_value)
            {
                player.Damage_Self();
                return;
            }
            player.points += 10;
        }    
    }
}
