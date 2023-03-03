using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;

public class HitState_Skeleton<T> : IState where T : BB_Skeleton
{
    T board;
   
    public HitState_Skeleton(T board)
    {
        this.board = board;
    }
    public void OnCheck(FSM_Enemy fSM_Enemy)
    {
       
    }

    public void OnEnter(FSM_Enemy fSM_Enemy)
    {
        board.animController.GetHit();
        board.animController.CurAnimInfo = board.anim.GetCurrentAnimatorStateInfo(0);
        
    }

    public void OnExit(FSM_Enemy fSM_Enemy)
    {
        
    }

    public void OnUpdate(FSM_Enemy fSM_Enemy)
    {
        board.animController.CurAnimInfo.IsName("GetHit");
        if (board.animController.CurAnimInfo.normalizedTime >= 0.95f)
        {
            Debug.Log("Out Hit");
            fSM_Enemy.SwitchState(StateType.MOVE, fSM_Enemy, board);
        }
    }

}
