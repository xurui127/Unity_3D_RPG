using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState_Player<T> : IState where T : BB_Player
{
    T board;
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
        board.animController.RollHaddler();
    }

    public void OnExit(StateMachine stateMachine)
    {
        Debug.Log("out Roll");

    }

    public void OnUpdate(StateMachine stateMachine)
    {

      
            if (board.input.Move&& board.animController.AnimIsFinished())
            {
                stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
            }
             if (board.input.Attack && board.animController.AnimIsFinished())
            {
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
            }
             if (board.input.Sprint && board.animController.AnimIsFinished())
            {
                stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
            }
        if (board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }




    }
}
