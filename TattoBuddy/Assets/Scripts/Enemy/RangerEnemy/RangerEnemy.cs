using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerEnemy : MainEnemy
{
    private ObjectsPool objectPool = null;

    private void Start()
    {
        objectPool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<ObjectsPool>();
        GameManager.instance.rangerEnemyDamageValue = damageValue;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Attack()
    {
        SetAttacking();
        StartCoroutine(AttackTimer(0));
    }

    private IEnumerator AttackTimer(int objectType)
    {

        yield return new WaitForSeconds(0.45f);
        if (isAttackable)
        {
            var obj = objectPool.GetPooledObject(objectType);
            obj.transform.position = transform.position;
            obj.GetComponent<LaserBall>().MoveBall();
            StartCoroutine(Disableobj(obj));
        }
        isAttackable = false;
        SetIdle();
        yield return new WaitForSeconds(attackTime);
        isAttackable = true;
    }

    // Object Disable
    IEnumerator Disableobj(GameObject obj)
    {
        yield return new WaitForSeconds(9);
        if (obj.activeSelf != false)
            obj.SetActive(false);
    }
}
