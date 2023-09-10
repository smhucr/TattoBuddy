using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainEnemy : MonoBehaviour
{

    [Header("MainPlayer")]
    protected Transform player;
    [Header("EnemyFeatures")]
    [SerializeField]
    protected float health;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected int shield;
    [SerializeField]
    protected int damageMultiplier;
    [SerializeField]
    protected float follow_distance;
    [SerializeField]
    protected float attackTime;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Move()
    {
        EnemyToPlayerDirection();
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed);
        }
        else
        {
            Attack();
        }
    }
    private void EnemyToPlayerDirection()
    {
        float direction = player.position.x - transform.position.x;
        if (direction > 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (direction < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, -180, 0));
        }

    }
    public /*abstract*/ void Attack()
    {

    }
    public /*abstract*/ void TakeDamage(int damageAmount)
    {

    }
}
