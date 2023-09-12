using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LaserBall : MonoBehaviour
{
    public float speed;
    public Transform playerPos;
    private Rigidbody2D rbBall;

    private void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rbBall = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {   
        transform.DORotate(new Vector3(0f, 0f, 360f), 0.5f , RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<MainPlayer>().TakeDamage(GameManager.instance.rangerEnemyDamageValue);
            gameObject.SetActive(false);
        }
    }
    public void MoveBall()
    {
        //BulletAcceleration  
        Vector2 shootingDirection = (playerPos.position - transform.position).normalized;
        rbBall.velocity = shootingDirection * speed;
    }

    private void OnDisable()
    {
        rbBall.velocity = new Vector2(0,0);
    }
}
