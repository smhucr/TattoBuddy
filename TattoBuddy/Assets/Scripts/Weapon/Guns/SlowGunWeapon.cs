using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGunWeapon : MainWeapon
{
    private void Awake()
    {
        shootingInterval = 0.75f;
        detectionRange = 6.0f;
        attackRange = 5.0f;
        animator = GetComponent<Animator>();
    }
    public override void ShootAtTarget()
    {
        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
            if (distance <= attackRange)
            {
                animator.SetBool("isAttack", true);
                var obj = objectPool.GetPooledObject(1);
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                Vector2 shootingDirection = (currentTarget.position - transform.position).normalized;
                obj.GetComponent<GunBullet>().MoveBullet(shootingDirection);
                // Fire Codes.
                Debug.Log("Shooting at: " + currentTarget.name);
            }
            else
                animator.SetBool("isAttack", false);
        }
        else
            animator.SetBool("isAttack", false);
    }
}
