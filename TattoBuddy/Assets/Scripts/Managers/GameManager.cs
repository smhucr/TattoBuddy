using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Components")]
    public DynamicJoystick joystick;
    [Header("Player")]
    public Rigidbody2D rb2D;
    public float playerSpeed;
    [Header("Enemy")]
    [Header("RangerEnemy")]
    public int rangerEnemyDamageValue;
    [Header("RunnerEnemy")]
    public int runnerEnemyDamageValue;
    [Header("TankEnemy")]
    public int tankEnemyDamageValue;

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    private void Awake()
    {
        MakeInstance();
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
}
