using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FinitStateMachine;
using UnityEngine.Rendering.Universal;

public class IdleState_Skeleton<T> : IState where T : BB_Skeleton
{
    T board;
    public IdleState_Skeleton(T board)
    {
        this.board = board;
    }
    public void OnCheck(FinitStateMachine.StateMachine fSM_Enemy)
    {
       
    }

    public void OnEnter(FinitStateMachine.StateMachine fSM_Enemy)
    {
        Debug.Log("In Idle");
    }

    public void OnExit(FinitStateMachine.StateMachine fSM_Enemy)
    {
        
    }

    public void OnUpdate(FinitStateMachine.StateMachine fSM_Enemy)
    {
        if (Input.GetKeyDown("1"))
        {
            fSM_Enemy.SwitchState(StateType.MOVE, fSM_Enemy,board);
        }
    }

}
