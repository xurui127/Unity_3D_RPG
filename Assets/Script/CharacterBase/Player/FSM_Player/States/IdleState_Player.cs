using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using static PlayerInputActions;

public class IdleState_Player<T> : IState where T : BB_Player
{
    T board;
    // public List<InputActionReference> canDoActions = new List<InputActionReference>();
    public List<string> canDoActions = new List<string>();

    public IdleState_Player(T board )
    {
        this.board = board;

    }

    public void OnCheck(StateMachine stateMachine)
    {
    }

    public void OnEnter(StateMachine stateMachine)
    {
       //Debug.Log("In Idle");
    }

    public void OnExit(StateMachine stateMachine)
    {
        //Debug.Log("out Idle");
    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (board.input.Move)
        {
            stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
        }
        if (board.input.Attack)
        {
            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
        }
        if (board.input.Roll)
        {
            stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
        }
        if (board.input.Sprint)
        {
            stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
        }
       
    }

}
