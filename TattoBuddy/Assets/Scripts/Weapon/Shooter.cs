using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float targettingInterval = 0.2f; // Hedef alma sýklýðý
    public float shootingInterval = 1.0f; // Ateþ etme sýklýðý
    public float detectionRange = 50.0f; // Düþmanlarý algýlama menzili
    public float maxRotationAngle = 180.0f; // Silahýn maksimum dönme açýsý
    public Transform currentTarget; // Þu anki hedef

    void Start()
    {
        // Hedef alma ve ateþ etme iþlevlerini belirli aralýklarla tekrarlamak için Coroutine kullanýlýr.
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
            print(direction);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (direction.x < 0)
            {
                float reverseAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(new Vector3(0, 180, reverseAngle + 90));
            }
            else
                transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        }
        else
            transform.localRotation = Quaternion.Euler(Vector3.zero);
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