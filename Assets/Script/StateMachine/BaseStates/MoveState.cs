using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;
public class MoveState : IState
{
    BlackBoard board;
    public MoveState(BlackBoard board)
    {
        this.board = board;
    }
    public void OnCheck(FSM_Enemy fSM_Enemy, BlackBoard board)
    {   
        
    }

    public void OnEnter(FSM_Enemy fSM_Enemy, BlackBoard board)
    {
        Debug.Log("In Move");
        //fSM_Enemy.board.agent.SetDestination(fSM_Enemy.board.target.transform.position);
        this.board.agent.SetDestination(board.target.transform.position);
        this.board.anim.OnMove(1.0f);
       
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
