using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SlowMeleeWeapon : MainWeapon
{
    public bool isAttacking = false;
    public Collider2D colliderWeapon;
    private void Awake()
    {
        shootingInterval = 3f;
        detectionRange = 6.0f;
        attackRange = 4.0f;
        colliderWeapon = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isAttacking)
        {
            print("SlowMelee Hitted ::: " + collision.name);
        }
    }

    public override void ShootAtTarget()
    {
        if (currentTarget != null)
            AttackAnimation();
    }

    public void AttackAnimation()
    {
        targettingInterval = 0.8f; // Temporary Solution for Image Tearing
        isAttacking = true;
        var tempWeaponPosition = transform.localPosition;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, currentTarget.position, 0.15f);
        transform.position = newPosition;
        Vector2 direction = currentTarget.position - transform.position;
        float startXRotation = transform.eulerAngles.x;
        float startYRotation = transform.eulerAngles.y;
        float startZRotation = transform.eulerAngles.z;
        transform.rotation = Quaternion.Euler(new Vector3(startXRotation, startYRotation, startZRotation + 90));
        if (direction.y > 0)
        {
            transform.DORotate(new Vector3(startXRotation, startYRotation, startZRotation - 120), 0.8f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            transform.localPosition = tempWeaponPosition;
                            ToNormalRotation();
                        });
            StartCoroutine(ColliderCloseOpen());
        }

        else
        {
            transform.DORotate(new Vector3(startXRotation, startYRotation, startZRotation - 80), 0.6f).SetEase(Ease.Linear).OnComplete(() =>
                        {
                            transform.localPosition = tempWeaponPosition;
                            ToNormalRotation();
                        });
            StartCoroutine(ColliderCloseOpen());
        }


    }

    public void ToNormalRotation()
    {
        if (currentTarget == null)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        targettingInterval = 0.2f;
        isAttacking = false;
    }

    IEnumerator ColliderCloseOpen()
    {
        colliderWeapon.enabled = true;
        yield return new WaitForSeconds(1f);
        colliderWeapon.enabled = false;
    }
}
