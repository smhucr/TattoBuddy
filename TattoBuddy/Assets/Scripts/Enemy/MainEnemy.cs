using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainEnemy : MonoBehaviour
{
    [Header("EnemyFeatures")]
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected int shield;
    [SerializeField]
    protected int damageMultiplier;

    public abstract void Move();
    public abstract void Attack();
    public abstract void TakeDamage(int damageAmount);
}
