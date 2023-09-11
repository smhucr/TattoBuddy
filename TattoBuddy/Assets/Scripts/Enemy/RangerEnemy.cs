using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MainEnemy
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    public override void Attack()
    {
        MainPlayer cachedPlayer = player.GetComponent<MainPlayer>();
        cachedPlayer.health -= damageValue;
        cachedPlayer.health = Mathf.Clamp(cachedPlayer.health, 0, 500);
        SetAttacking();
        StartCoroutine(AttackTimer());
    }

    private IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(0.45f);
        isAttackable = false;
        SetIdle();
        yield return new WaitForSeconds(attackTime);
        isAttackable = true;
    }
}
