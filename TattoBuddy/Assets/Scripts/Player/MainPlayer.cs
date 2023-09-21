using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainPlayer : MonoBehaviour
{
    [Header("CharacterFeatures")]
    [SerializeField]
    public float health;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public int shield;
    [SerializeField]
    public int healthRegenerate;
    [SerializeField]
    public int damageMultiplier;
    [SerializeField]
    public int dodgeRate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    public void TakeDamage(float damageValue)
    {
        health -= damageValue;
        health = Mathf.Clamp(health, 0, 500);
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        print("I'm Dead Bruah");
    }
}
