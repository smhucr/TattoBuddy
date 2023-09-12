using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MainEnemy
{
    private void Start()
    {
        GameManager.instance.runnerEnemyDamageValue = damageValue;
    }
    private void FixedUpdate()
    {
        Move();
    }
    public override void Attack()
    {
        SetAttacking();
        StartCoroutine(AttackTimer());
    }

    private IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.4f);
        if (isAttackable)
            player.GetComponent<MainPlayer>().health -= GameManager.instance.tankEnemyDamageValue; // -= damageValue olabilir
        isAttackable = false;
        SetIdle();
        yield return new WaitForSeconds(attackTime);
        isAttackable = true;
    }
}
