using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace AI_Enemy
{
    public interface IState
    {
        public void OnEnter(FSM_Enemy fSM_Enemy);
        public void OnExit(FSM_Enemy fSM_Enemy);
        public void OnUpdate(FSM_Enemy fSM_Enemy);
        public void OnCheck(FSM_Enemy fSM_Enemy);

    }
}