using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainWeapon : MonoBehaviour
{
    [Header("WeaponFeature")]
    [SerializeField]
    protected float targettingInterval = 0.2f; // Hedef alma sýklýðý
    [SerializeField]
    protected float shootingInterval = 1.0f; // Ateþ etme sýklýðý
    [SerializeField]
    protected float detectionRange = 50.0f; // Düþmanlarý algýlama menzili
    [SerializeField]
    protected float attackRange = 20.0f; // Düþmanlara saldýrma menzili
    [SerializeField]
    protected int damage = 1;
    [Header("Enemy")]
    [SerializeField]
    protected Transform currentTarget; // Þu anki hedef
    [Header("WeaponComponents")]
    [SerializeField]
    protected Animator animator;

    public ObjectsPool objectPool = null;
    public abstract void ShootAtTarget();
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

}