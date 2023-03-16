using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckAttackState_Player<T> : IState where T : BB_Player
{
    private T board;
    private int attackIndex;

    public CheckAttackState_Player(T board)
    {
        this.board = board;
    }

    public void OnCheck(StateMachine stateMachine)
    {

    }

    public void OnEnter(StateMachine stateMachine)
    {
    }

    public void OnExit(StateMachine stateMachine)
    {
    }

    public void OnUpdate(StateMachine stateMachine)
    {
    }
}


