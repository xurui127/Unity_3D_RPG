using NPC_Player;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Move : Commend
{
    public override void Execute(BB_Player board)
    {
        board.animController.OnMove(board.input.moveValue.magnitude);
        board.playerController.Move(board.input.moveValue * board.moveSpeed * Time.deltaTime);
    }
}

public class Rotation : Commend
{
    public override void Execute(BB_Player board)
    {
        board.transform.rotation = Quaternion.LookRotation(board.input.moveValue, Vector3.up);
    }
}
public class Roll : Commend
{

    public override void Execute(BB_Player board)
    {
        board.animController.RollHaddler();
    }
}

public class Attack : Commend
{

    public override void Execute(BB_Player board)
    {
        board.animController.OnAttack();
    }
}
public class Sprint : Commend
{
    public override void Execute(BB_Player board)
    {
        board.animController.SprintHaddler();
    }
}
