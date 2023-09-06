using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainPlayer : MonoBehaviour
{
    [Header("CharacterFeatures")]
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected int shield;
    [SerializeField]
    protected int healthRegenerate;
    [SerializeField]
    protected int damageMultiplier;
    [SerializeField]
    protected int dodgeRate;
    


    public void TakeDamage()
    {

    }

}
