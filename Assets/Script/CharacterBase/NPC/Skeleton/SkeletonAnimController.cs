using UnityEngine;

public class SkeletonAnimController : AnimController
{
    public string moveTxt = "Locomotion";
    public string move = "speed";
    public string attackTxt = "attacks";

    protected override void Start()
    {
        base.Start();
    }

    public override void OnMove(float speed)
    {
        SetAnimation(move, speed);
    }

    public override void OnAttack()
    {
        int randomAttack = Random.Range(1, 2);
        SetAnimation(attackTxt + randomAttack);
    }
    public override void GetHit()
    {
        SetAnimation("gethit");
    }
    protected override void Dead()
    {

    }
}

