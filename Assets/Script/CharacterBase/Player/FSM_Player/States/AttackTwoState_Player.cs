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
        UnityEngine.Debug.Log("In Attack 2");

        board.animController.OnAttack(attackIndex);

    }

    public void OnExit(StateMachine stateMachine)
    {
        UnityEngine.Debug.Log("out Attack 2");
    }

    public void OnUpdate(StateMachine stateMachine)
    {
    }
}
