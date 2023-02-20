using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimController : AnimController
{
    public string moveTxt = "Locomotion";
    public string attackTxt = "attacks";

    protected override void Start()
    {
        base.Start();
    }

    public override void OnMove(float speed)
    {
        SetAnimation(moveTxt,speed);
    }

    public override void OnAttack()
    {
        int randomAttack = Random.Range(1, 2);
        SetAnimation(attackTxt + randomAttack);
    }

    protected override void Dead()
    {
        
    }
}

