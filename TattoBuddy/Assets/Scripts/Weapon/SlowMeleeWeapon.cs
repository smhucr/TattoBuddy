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
        AttackAnimation();
    }

    public void AttackAnimation()
    {
        float startXRotation = transform.eulerAngles.x;
        float startYRotation = transform.eulerAngles.y;
        float startZRotation = transform.eulerAngles.z;
        transform.DORotate(new Vector3(startXRotation, startYRotation, startZRotation - 360), 1f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() => ToNormalRotation());
    }

    public void ToNormalRotation()
    {
        if (currentTarget == null)
            transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
