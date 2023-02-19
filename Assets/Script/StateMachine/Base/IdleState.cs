using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI_Enemy;

public class IdleState : IState
{
    public void OnCheck(FSM_Enemy fSM_Enemy)
    {
        
    }

    public void OnEnter(FSM_Enemy fSM_Enemy)
    {
      
        
    }

    public void OnExit(FSM_Enemy fSM_Enemy)
    {
    
    }

    public void OnUpdate(FSM_Enemy fSM_Enemy)
    {
        if (Input.GetKeyDown("1"))
        {
            fSM_Enemy.SwitchState(StateType.MOVE, fSM_Enemy);
        }
    }
}
