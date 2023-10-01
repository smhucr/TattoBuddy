using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rbBall;

    private void Awake()
    {
        rbBall = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //collision.GetComponent<MainEnemy>().TakeDamage(GameManager.instance.rangerEnemyDamageValue);
            gameObject.SetActive(false);
        }
    }
    public void MoveBullet(Vector2 direction)
    {
        rbBall.velocity = speed * direction;
    }

    private void OnDisable()
    {
        rbBall.velocity = new Vector2(0, 0);
    }
}
