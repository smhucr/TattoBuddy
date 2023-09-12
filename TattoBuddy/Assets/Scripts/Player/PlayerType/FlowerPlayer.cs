using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPlayer : MainPlayer
{
    private void Awake()
    {
        this.health = 5;
        this.moveSpeed = 40;
        this.shield = 5;
        this.healthRegenerate = 0;
        this.damageMultiplier = 5;
        this.dodgeRate = 0;
        GameManager.instance.playerSpeed = moveSpeed;
    }
}
