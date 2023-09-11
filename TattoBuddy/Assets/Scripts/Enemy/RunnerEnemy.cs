using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : MainEnemy
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }
    public override void Attack()
    {
        animator.SetBool("isAttack", true);
        animator.SetBool("isWalking", false);
    }
}
