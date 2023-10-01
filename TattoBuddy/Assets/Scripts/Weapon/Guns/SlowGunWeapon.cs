using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowGunWeapon : MainWeapon
{
    private void Awake()
    {
        shootingInterval = 0.75f;
        detectionRange = 50.0f;
    }
}
