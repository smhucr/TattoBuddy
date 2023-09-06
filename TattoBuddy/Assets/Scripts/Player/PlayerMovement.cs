using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private DynamicJoystick joystick;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = GameManager.instance.playerSpeed;
        joystick = GameManager.instance.joystick;
        rb2D = GameManager.instance.rb2D;
    }
    private void Update()
    {
        movement = new Vector2(joystick.Horizontal, joystick.Vertical);
    }

    private void FixedUpdate()
    {
        Vector2 cachedMovement = moveSpeed * Time.deltaTime * movement; // Math Operations F*F*V2
        rb2D.velocity = cachedMovement;
    }
}
