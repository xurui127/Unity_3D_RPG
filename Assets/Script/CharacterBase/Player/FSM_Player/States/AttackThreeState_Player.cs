using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class AttackThreeState_Player<T> : IState where T : BB_Player
{
    private T board;
    private int attackIndex = 3;
    private float lastAttackTime;
    private float comboTimeLimit;
    bool combo;
    public AttackThreeState_Player(T board)
    {
        this.board = board;
        comboTimeLimit = 1f;
        
        
    }

    public void OnCheck(StateMachine stateMachine)
    {
    }

    public void OnEnter(StateMachine stateMachine)
    {
        combo = false;
        lastAttackTime = Time.time;
        board.animController.OnAttack(attackIndex);
    }

    public void OnExit(StateMachine stateMachine)
    {
        board.input.ClearInputCache();

    }

    public void OnUpdate(StateMachine stateMachine)
    {

        if (board.animController.CanDoCombo(0.55f, 1f))
        {
            if (board.input.Attack)
            {
                stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board,0);
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





    }
}

//if (board.input.Attack)
//{
//    if (Time.time - lastAttackTime <= attackTimeOut)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
//    }
//    else
//    {
//        stateMachine.SwitchState(StateType.IDLE, stateMachine, board);
//    }
//}
//if (board.input.Attack)
//{
//    inputList.Add(StateType.ATTACK);
//}
//if (board.input.Roll)
//{
//    inputList.Add(StateType.ROLL);
//}
//if (board.input.Sprint)
//{
//    inputList.Add(StateType.SPRINT);
//}

//if (board.animController.IsInCombo())
//{
//    if (inputList.Count != 0)
//    {
//        var input = inputList[inputList.Count - 1];
//        inputList.Clear();
//        if (input == StateType.ATTACK)
//        {
//            stateMachine.SwitchSubState(input, stateMachine, board, 0);

//        }
//        else
//        {
//            stateMachine.SwitchState(input, stateMachine, board);
//        }
//    }

//}
//if (board.animController.IsInCombo())
//{
//    if (board.input.Attack)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 0);
//    }
//    else if (board.input.Sprint)
//    {
//        stateMachine.SwitchState(StateType.SPRINT, stateMachine, board);
//    }
//    else if (board.input.Roll)
//    {
//        stateMachine.SwitchState(StateType.ROLL, stateMachine, board);
//    }
//}