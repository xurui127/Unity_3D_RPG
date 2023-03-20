using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RollState_Player<T> : IState where T : BB_Player
{
    T board;
    string roll = "Roll_Battle_SwordAndShield";
    public RollState_Player(T board)
    {
        this.board = board;
    }
    public void OnCheck(StateMachine stateMachine)
    {

    }

    public void OnEnter(StateMachine stateMachine)
    {
        Debug.Log("in Roll");
        board.animController.OnRoll();

    }

    public void OnExit(StateMachine stateMachine)
    {
        Debug.Log("out Roll");

    }

    public void OnUpdate(StateMachine stateMachine)
    {

        if (board.input.Attack && !board.animController.IsInAction())
        {
            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
        }
        if (board.input.Move && !board.animController.IsInAction())
        {
            stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
        }

        if (board.input.Sprint && !board.animController.IsInAction())
        {
            stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
        }
        if (!board.animController.IsInAction())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }


    }
    //    if (board.input.Attack && board.animController.AnimIsFinished())
    //        {
    //            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
    //        }
    //if (board.input.Move && board.animController.AnimIsFinished())
    //{
    //    stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
    //}

    //if (board.input.Sprint && board.animController.AnimIsFinished())
    //{
    //    stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
    //}
    //if (board.animController.AnimIsFinished())
    //{
    //    stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
    //}
}
