using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Components")]
    public DynamicJoystick joystick;
    public Rigidbody2D rb2D;
    public float playerSpeed;

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
