using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int points;
    public float health;
    public bool dead;
    public int complementary_value;

    public GameObject death_particle;

    public void Damage_Self()
    {
        if (!dead)
        {
            health -= 1;
            dead = health == 0;
            return;
        }
        Destroy(gameObject);
        Instantiate(death_particle, transform.position, Quaternion.identity);
    }
}
