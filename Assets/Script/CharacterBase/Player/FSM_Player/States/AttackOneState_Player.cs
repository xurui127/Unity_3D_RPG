using FinitStateMachine;
using NPC_Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOne_Player<T>:IState where T :BB_Player
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
        UnityEngine.Debug.Log("In Attack 1");
       
        board.animController.OnAttack(attackIndex);

    }

    public void OnExit(StateMachine stateMachine)
    {
        UnityEngine.Debug.Log("out Attack 1");
    }

    public void OnUpdate(StateMachine stateMachine)
    {

    }
}
