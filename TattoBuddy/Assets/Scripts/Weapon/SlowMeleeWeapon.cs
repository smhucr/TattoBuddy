using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMeleeWeapon : MainWeapon
{
    private void Awake()
    {
        shootingInterval = 0.7f;
        detectionRange = 6.0f;
        attackRange = 4.0f;
    }


    public override void ShootAtTarget()
    {
        
        throw new System.NotImplementedException();
    }
}
