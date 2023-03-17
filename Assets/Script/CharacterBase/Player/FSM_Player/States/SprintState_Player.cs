using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState_Player<T> : IState where T : BB_Player
{
    T board;
    public SprintState_Player(T board)
    {
        this.board = board;
    }
    public void OnCheck(StateMachine stateMachine)
    {
       
    }

    public void OnEnter(StateMachine stateMachine)
    {
        Debug.Log("in Sprint");
        board.animController.SprintHaddler();
    }

    public void OnExit(StateMachine stateMachine)
    {
        Debug.Log("out Sprint");

    }

    public void OnUpdate(StateMachine stateMachine)
    {
        

             if (board.input.Attack && board.animController.AnimIsFinished())
            {
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
            }
            if (!board.input.Move && board.animController.AnimIsFinished())
            {
                stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
            }
             if (board.input.Roll && board.animController.AnimIsFinished())
            {
                stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
            }
        if (board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }




    }
}
