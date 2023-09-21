using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainWeapon : MonoBehaviour
{
    protected float targettingInterval;// = 0.2f; // TargetTime
    protected float shootingInterval;// = 1.0f; // FireTime
    protected float shootingRange; // = 1.5f; // FireRange
    protected bool isShootable = true;
    protected float detectionRange;// = 2.1f; // EnemyDetectRange
    [SerializeField]
    private Transform currentTarget; // Target

    private void Start()
    {
        StartCoroutine(TargettingRoutine());
        StartCoroutine(ShootingRoutine());
    }

    IEnumerator TargettingRoutine()
    {
        while (true)
        {
            TargetClosestEnemy();
            yield return new WaitForSeconds(targettingInterval);
        }
    }

    IEnumerator ShootingRoutine()
    {
        while (true)
        {
            ShootAtTarget();
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    public void TargetClosestEnemy()
    {
        Vector3 cachedPlayerPosition = transform.position;
        Vector2 cachedPosition = new Vector2(cachedPlayerPosition.x, cachedPlayerPosition.y);
        Collider2D[] hits = Physics2D.OverlapCircleAll(cachedPosition, detectionRange);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(cachedPlayerPosition, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hit.transform;
                }
            }
        }

        currentTarget = closestEnemy;

        if (currentTarget != null)
        {
            Vector2 direction = currentTarget.position - cachedPlayerPosition;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public void ShootAtTarget()
    {
        if (currentTarget != null)
        {
            // Fire Codes.
            Debug.Log("Shooting at: " + currentTarget.name);
        }
    }
}
