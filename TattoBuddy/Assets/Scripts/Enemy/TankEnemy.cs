using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MainEnemy
{
    private void Start()
    {
        GameManager.instance.tankEnemyDamageValue = damageValue;
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
        yield return new WaitForSeconds(0.45f);
        if (isAttackable)
            player.GetComponent<MainPlayer>().health -= GameManager.instance.tankEnemyDamageValue; // -= damageValue olabilir
        isAttackable = false;
        SetIdle();
        yield return new WaitForSeconds(attackTime);
        isAttackable = true;
    }
}
