using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimController : AnimController
{
    //public string moveTxt = "Locomotion";
    //public string move = "speed";
    //public string attackTxt = "attacks";


    [SerializeField] private SkeletonPreTxts_SO skeletonPreTxt;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnMove(float speed)
    {
        SetAnimation(skeletonPreTxt.moveTxt, speed);
    }

    public override void OnAttack()
    {
        int randomAttack = Random.Range(1, 2);
        SetAnimation(skeletonPreTxt.attackTxt + randomAttack);
    }
    public override void GetHit()
    {
        SetAnimation("gethit"); 
    }
    protected override void Dead()
    {
        
    }
}

