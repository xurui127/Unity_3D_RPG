using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTwoState_Player<T> : IState where T : BB_Player
{
    private T board;
    private int attackIndex = 2;

    public AttackTwoState_Player(T board)
    {
        this.board = board;
        
    }

    public void OnCheck(StateMachine stateMachine)
    {
    }

    public void OnEnter(StateMachine stateMachine)
    {

        board.animController.OnAttack(attackIndex);

    }

    public void OnExit(StateMachine stateMachine)
    {
    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (board.animController.CanDoCombo())
        {
            if (board.input.Attack)
            {
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 2);
            }
            else if (board.input.Sprint)
            {
                stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
            }
            else if (board.input.Roll)
            {
                stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
            }
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
