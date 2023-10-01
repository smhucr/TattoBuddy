using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainWeapon : MonoBehaviour
{
    protected float targettingInterval = 0.2f; // Hedef alma sýklýðý
    protected float shootingInterval = 1.0f; // Ateþ etme sýklýðý
    protected float detectionRange = 50.0f; // Düþmanlarý algýlama menzili
    protected int damage = 1;
    protected Transform currentTarget; // Þu anki hedef

    public ObjectsPool objectPool = null;
    void Start()
    {
        objectPool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<ObjectsPool>();
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
            var obj = objectPool.GetPooledObject(1);
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            Vector2 shootingDirection = (currentTarget.position - transform.position).normalized;
            obj.GetComponent<GunBullet>().MoveBall(shootingDirection);
            // Fire Codes.
            print(obj);
            Debug.Log("Shooting at: " + currentTarget.name);
        }
    }
}