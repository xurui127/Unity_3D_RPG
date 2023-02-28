using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;

public class IdleState : IState
{
    BlackBoard board;
    public IdleState(BlackBoard board)
    {
        this.board = board;
    }
    public void OnCheck(FSM_Enemy fSM_Enemy, BlackBoard board)
    {
       
    }

    public void OnEnter(FSM_Enemy fSM_Enemy, BlackBoard board)
    {
        Debug.Log("Idle");
    }

    public void OnExit(FSM_Enemy fSM_Enemy, BlackBoard board)
    {
    
    }

    public void OnUpdate(FSM_Enemy fSM_Enemy, BlackBoard board)
    {
        if (Input.GetKeyDown("1"))
        {
            fSM_Enemy.SwitchState(StateType.MOVE, fSM_Enemy,board);
        }
    }
}
