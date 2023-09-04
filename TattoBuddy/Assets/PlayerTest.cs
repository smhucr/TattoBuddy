using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private DynamicJoystick joystick;
    private Rigidbody2D rigidbod2D;
    [SerializeField]
    private float moveSpeed = 2;
    private Vector2 movement;

    private void Start()
    {
        rigidbod2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = new Vector2(joystick.Horizontal, joystick.Vertical);
    }

    private void FixedUpdate()
    {
        Vector2 cachedMovement = moveSpeed * Time.deltaTime * movement;
        rigidbod2D.velocity = cachedMovement;

    }
}
