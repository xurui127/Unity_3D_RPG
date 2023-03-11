using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FinitStateMachine;
public class MoveState_Skeleton<T> : IState where T : BB_Skeleton
{
    T board;
    public MoveState_Skeleton(T board)
    {
        this.board = board;
    }
    public void OnCheck(FinitStateMachine.StateMachine fSM_Enemy)
    {   
        
    }

    public void OnEnter(FinitStateMachine.StateMachine fSM_Enemy)
    {
        Debug.Log("In Move");
        //fSM_Enemy.board.agent.SetDestination(fSM_Enemy.board.target.transform.position);
        this.board.agent.SetDestination(board.target.transform.position);
        this.board.animController.OnMove(1.0f);
       
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
