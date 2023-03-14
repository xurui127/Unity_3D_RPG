using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState_Player<T> : IState where T : BB_Player
{
    T board;
    public MoveState_Player(T board)
    {
        this.board = board;
    }
    public void OnCheck(StateMachine stateMachine)
    {
        board.animController.OnMove(board.input.moveValue.magnitude);
        board.playerController.Move(board.input.moveValue * board.moveSpeed * Time.deltaTime);
        board.transform.rotation = Quaternion.LookRotation(board.input.moveValue, Vector3.up);
    }

    public void OnEnter(StateMachine stateMachine)
    {
        //Debug.Log("In Move");
    }

    public void OnExit(StateMachine stateMachine)
    {
        //Debug.Log("out Move");

    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (!board.input.Move)
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }
        if (board.input.Attack)
        {
            stateMachine.SwitchState(StateType.ATTACK, stateMachine, board);
        }
    }
}
