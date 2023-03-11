using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace FinitStateMachine
{
   
    public interface IState
    {
        public void OnEnter(StateMachine fSM_Enemy);
        public void OnExit(StateMachine fSM_Enemy);
        public void OnUpdate(StateMachine fSM_Enemy);
        public void OnCheck(StateMachine fSM_Enemy);

        
    }
}