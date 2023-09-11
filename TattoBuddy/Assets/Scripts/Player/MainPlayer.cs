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
    


    public void TakeDamage()
    {

    }

}
