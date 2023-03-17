using FinitStateMachine;
using NPC_Player;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
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
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 1);
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
        if (board.input.Move && board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.MOVE, stateMachine, board);
        }
        if (board.animController.AnimIsFinished())
        {
            stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
        }

    }
    //private bool CanDoCombo()
    //{
    //    for(int i = 0; )

    //    return false;
    //}
}
