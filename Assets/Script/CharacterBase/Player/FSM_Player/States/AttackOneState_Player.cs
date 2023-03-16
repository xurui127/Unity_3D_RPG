using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AttackOne_Player<T> : IState where T : BB_Player
{
    private T board;
    private int attackIndex = 1;

    public AttackOne_Player(T board)
    {
        this.board = board;
    }
    public void OnCheck(StateMachine stateMachine)
    {

    }

    public void OnEnter(StateMachine stateMachine)
    {
        UnityEngine.Debug.Log("In Attack 1");

        board.animController.OnAttack(attackIndex);

    }

    public void OnExit(StateMachine stateMachine)
    {
        UnityEngine.Debug.Log("out Attack 1");
    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (board.input.Attack && board.animController.CanDoCombo())
        {
            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
        }
        if (board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }
        if (board.input.Move && board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
        }
    }
}
