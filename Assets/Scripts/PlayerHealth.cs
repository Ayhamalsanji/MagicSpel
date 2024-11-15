using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HeartCounter;

    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public int health, maxHealth;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        HeartCounter.GetComponent<heartHealthBar2>().UpdateHealth(health);


        if (health <= 0)
        {
            health = 0;
            Debug.Log("You're dead");
            OnPlayerDeath?.Invoke();
        }
    }
}
