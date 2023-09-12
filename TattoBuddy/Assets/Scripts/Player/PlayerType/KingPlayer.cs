using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingPlayer : MainPlayer
{
    private void Awake()
    {
        this.health = 25;
        this.moveSpeed = 100;
        this.shield = 5;
        this.healthRegenerate = 0;
        this.damageMultiplier = 5;
        this.dodgeRate = 0;
        GameManager.instance.playerSpeed = moveSpeed;
    }

}

