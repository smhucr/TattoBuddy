using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float targettingInterval = 0.2f; // Hedef alma s�kl���
    public float shootingInterval = 1.0f; // Ate� etme s�kl���
    public float detectionRange = 50.0f; // D��manlar� alg�lama menzili
    public Transform currentTarget; // �u anki hedef

    void Start()
    {
        // Hedef alma ve ate� etme i�levlerini belirli aral�klarla tekrarlamak i�in Coroutine kullan�l�r.
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

    void TargetClosestEnemy()
    {
        Vector2 cachedPosition = new Vector2(transform.position.x, transform.position.y);
        Collider2D[] hits = Physics2D.OverlapCircleAll(cachedPosition, detectionRange);

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
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
            Vector2 direction = currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void ShootAtTarget()
    {
        if (currentTarget != null)
        {
            // Fire Codes.
            Debug.Log("Shooting at: " + currentTarget.name);
        }
    }
}