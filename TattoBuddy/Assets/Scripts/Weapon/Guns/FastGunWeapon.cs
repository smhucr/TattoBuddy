using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastGunWeapon : MainWeapon
{
    private void Awake()
    {
        shootingInterval = 0.25f;
        detectionRange = 20.0f;
    }
}
