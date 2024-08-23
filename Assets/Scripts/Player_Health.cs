using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public static Player_Health instance;

    public int health = 100;
    private int MAX_HEALTH = 100;

    public HealthBar healthBar;
    private void Awake()
    {
        instance = this;
    }

    public int get_health()
    {
        return health;
    }

    public int get_maxhealth()
    {
        return MAX_HEALTH;
    }

    private void Start()
    {
        health = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }
        else
        {
            this.health -= amount;
        }

        if (health <= 0)
        {
            Die();
        }

        healthBar.SetHealth(health);
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing.");
        }

        if (this.health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        healthBar.SetHealth(health);
    }

    public void Die()
    {
        Debug.Log("You died.");
        Destroy(gameObject);
    }
}
