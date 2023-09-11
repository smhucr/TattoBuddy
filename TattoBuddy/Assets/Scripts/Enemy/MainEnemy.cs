using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainEnemy : MonoBehaviour
{

    [Header("MainPlayer")]
    public Transform player;
    [Header("EnemyFeatures")]
    [SerializeField]
    public float health;
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public int shield;
    [SerializeField]
    public int damageValue;
    [SerializeField]
    public float follow_distance;
    [SerializeField]
    public float attackTime;
    [SerializeField]
    public bool isAttackable;
    [Header("EnemyComponent")]
    [SerializeField]
    public Animator animator;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        isAttackable = true;
    }
    public void Move()
    {
        EnemyToPlayerDirection();
        if (Vector3.Distance(transform.position, player.position) >= follow_distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * moveSpeed);
            SetWalking();
        }
        else
        {
            if (isAttackable)
                Attack();
            else
                SetIdle();

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
    public abstract void Attack();
    public /*abstract*/ void TakeDamage(int damageAmount)
    {

    }

    public void SetIdle()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttack", false);
        animator.SetBool("isStop", true);
    }
    public void SetWalking()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttack", false);
        animator.SetBool("isStop", false);
    }
    public void SetAttacking()
    {
        animator.SetBool("isAttack", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isStop", false);
    }
}
