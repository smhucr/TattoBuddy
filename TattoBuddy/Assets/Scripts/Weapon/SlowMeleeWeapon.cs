using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SlowMeleeWeapon : MainWeapon
{
    private void Awake()
    {
        shootingInterval = 3f;
        detectionRange = 6.0f;
        attackRange = 4.0f;
    }


    public override void ShootAtTarget()
    {
        if (currentTarget != null)
            AttackAnimation();
    }

    public void AttackAnimation()
    {
        var tempWeaponPosition = transform.localPosition;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget.position, 0.15f);
        transform.position = newPosition;
        Vector2 direction = currentTarget.position - transform.position;
        float startXRotation = transform.eulerAngles.x;
        float startYRotation = transform.eulerAngles.y;
        float startZRotation = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(new Vector3(startXRotation, startYRotation, startZRotation + 90));
        if (direction.y > 0)
            transform.DORotate(new Vector3(startXRotation, startYRotation, startZRotation - 120), 0.8f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() =>
            {
                ToNormalRotation();
                transform.localPosition = tempWeaponPosition;
            });
        else
            transform.DORotate(new Vector3(startXRotation, startYRotation, startZRotation - 80), 0.6f).SetEase(Ease.Linear).OnComplete(() =>
            {
                ToNormalRotation();
                transform.localPosition = tempWeaponPosition;
            });

    }

    public void ToNormalRotation()
    {
        if (currentTarget == null)
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
