using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace FinitStateMachine
{
   
    public interface IState
    {
        public void OnEnter(StateMachine stateMachine);
        public void OnExit(StateMachine stateMachine);
        public void OnUpdate(StateMachine stateMachine);
        public void OnCheck(StateMachine stateMachine);

        
    }
}