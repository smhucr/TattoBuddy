using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MainEnemy
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
        isAttackable = false;
        SetIdle();
        yield return new WaitForSeconds(attackTime);
        isAttackable = true;
    }
}
