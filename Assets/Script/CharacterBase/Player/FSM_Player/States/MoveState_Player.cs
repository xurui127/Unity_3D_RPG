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
        //board.animController.OnMove(board.input.moveValue.magnitude);
        //board.playerController.Move(board.input.moveValue * board.moveSpeed * Time.deltaTime);board.animController.OnMove(board.input.moveValue.magnitude);
        board.animController.OnMove(board.input.movementInput.magnitude);
        board.playerController.Move(board.input.movementInput * board.moveSpeed * Time.deltaTime);
        //board.transform.rotation = Quaternion.LookRotation(board.newPlayerInput.movementInput, Vector3.up);
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

        if (board.input.Attack)
        {
            stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
        }
        else if (board.input.Roll)
        {
            stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
        }
        else if (board.input.Sprint)
        {
            stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
        }
        else if (!board.input.Move)
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);

        }

    }
}
