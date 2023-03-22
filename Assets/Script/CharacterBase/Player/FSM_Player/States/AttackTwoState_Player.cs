using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
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
        CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackBegin.ToString());

    }

    public void OnExit(StateMachine stateMachine)
    {
    
        CombatEventManager.Instance.TriggerEventListener(NPCEventType.AttackEnd.ToString());


    }

    public void OnUpdate(StateMachine stateMachine)
    {
        if (board.animController.CanDoCombo(0.7f, 1f))
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



    }
}
//if (board.input.Attack)
//{
//    if (Time.time - lastAttackTime <= attackTimeOut)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 2);
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
//            stateMachine.SwitchSubState(input, stateMachine, board, 2);

//        }
//        else
//        {
//            stateMachine.SwitchState(input, stateMachine, board);
//        }
//    }

//}
//if (board.animController.CanDoCombo())
//{
//    if (board.input.Attack)
//    {
//        stateMachine.SwitchSubState(StateType.ATTACK, stateMachine, board, 2);
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